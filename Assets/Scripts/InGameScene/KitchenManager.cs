using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using System;
using Photon.Realtime;

public class KitchenManager : MonoBehaviour
{
    // UI 
    public CardManager cm;
    public ScoreController scoreCtr;
    public CreateDish createDish;

    public int successSubmit;       //성공한 주문 갯수
    public int score;               //득점
    public int tipScore;            //팁
    public int failSubmit;          //실패한 주문 갯수
    public int lostScore;           //실패 점수

    public int SuccessSubmit => successSubmit;
    public int Score => score;
    public int TipScore => tipScore;
    public int FailSubmit => failSubmit;
    public int LostScore => lostScore;

    public VirtualJoyStick JoyStick;

    public Button GrabButton;
    public Button KnifeButton;
    public Button SwitchButton;

    private int feverLevel;

    public GameObject playerPrefab;
    public List<Transform> SpawnPoints = new List<Transform>();

    public void Start()
    {
        

        Debug.Log(PhotonNetwork.CurrentRoom.PlayerCount);

        if (PhotonNetwork.CurrentRoom.PlayerCount <= 1)
        {
            InstanciateSinglePlayer(0);
            GameObject myPlayer2 =  InstanciateSinglePlayer(1);
            myPlayer2.GetComponent<SinglePlay>().Toggle();
        }
        else
        {
            int idx = Array.IndexOf(PhotonNetwork.PlayerList, PhotonNetwork.LocalPlayer);

            GameObject myPlayer = PhotonNetwork.Instantiate(playerPrefab.name, SpawnPoints[idx].position, SpawnPoints[idx].rotation);
            myPlayer.GetComponent<RandomChef>().Send(idx);

            //myPlayer.GetComponent<InputHandler>().enabled = true;
        }
    }

    public GameObject InstanciateSinglePlayer(int idx)
    {
        GameObject myPlayer = PhotonNetwork.Instantiate(playerPrefab.name, SpawnPoints[idx].position, SpawnPoints[idx].rotation);
        myPlayer.AddComponent<SinglePlay>();
        myPlayer.GetComponent<RandomChef>().Send(0);

        InputHandler inputHandler = myPlayer.GetComponent<InputHandler>();
        inputHandler.joystick = JoyStick;
        inputHandler.GrabButton = GrabButton;
        inputHandler.KnifeButton = KnifeButton;

        SinglePlay singlePlay = myPlayer.GetComponent<SinglePlay>();
        singlePlay.SwitchButton = SwitchButton;

        return myPlayer;
    }

    private void Update()
    {
        GameManager.Instance.DataManager.currentStageInfo[GameVariable.GetDefinition().JsonIndex].successSubmit = successSubmit;
        GameManager.Instance.DataManager.currentStageInfo[GameVariable.GetDefinition().JsonIndex].tipScore = tipScore;
        GameManager.Instance.DataManager.currentStageInfo[GameVariable.GetDefinition().JsonIndex].failSubmit = failSubmit;
        GameManager.Instance.DataManager.currentStageInfo[GameVariable.GetDefinition().JsonIndex].lostScore = lostScore;
        GameManager.Instance.DataManager.currentStageInfo[GameVariable.GetDefinition().JsonIndex].score = score;
        GameManager.Instance.DataManager.currentStageInfo[GameVariable.GetDefinition().JsonIndex].totalScore = score + tipScore - lostScore;
    }

    void CalledOnLevelWasLoaded(int level)
    {
        Debug.Log("CalledOnLevelWasLoaded");
    }

    public void OnSubmit(GameObject go)
    {
        cm.OnSubmit(go);
        createDish.GenerateDish(); //접시 타이밍
    }

    public void GetScore(int score, bool isFever)
    {
        var result = score;
        this.score += result;
        if (isFever)
        {
            var tip = (int)(score * 0.1f) * feverLevel;
            tipScore += tip;
            result += tip;
            feverLevel++;
            if (feverLevel > 4)
            {
                feverLevel = 4;
            }
        }
        else
        {
            feverLevel = 0;
        }
        successSubmit++;
        scoreCtr.GetScore(result, isFever, feverLevel);
    }

    public void LostScores(int lostScore)
    {
        this.lostScore += lostScore;
        failSubmit++;
        scoreCtr.LostScore(lostScore);
    }

    public void WrongSubmit()
    {
        scoreCtr.WrongSubmit();
    }
}
