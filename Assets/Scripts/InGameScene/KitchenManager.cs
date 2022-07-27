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

    public int successSubmit;       //������ �ֹ� ����
    public int score;               //����
    public int tipScore;            //��
    public int failSubmit;          //������ �ֹ� ����
    public int lostScore;           //���� ����

    public int SuccessSubmit => successSubmit;
    public int Score => score;
    public int TipScore => tipScore;
    public int FailSubmit => failSubmit;
    public int LostScore => lostScore;


    private int feverLevel;

    public GameObject playerPrefab;
    public List<Transform> SpawnPoints = new List<Transform>();

    public void Start()
    {
        

        Debug.Log(PhotonNetwork.CountOfPlayers);

        if (PhotonNetwork.CountOfPlayers == 1)
        {
            GameObject myPlayer1 = PhotonNetwork.Instantiate(playerPrefab.name, SpawnPoints[0].position, SpawnPoints[0].rotation);
            GameObject myPlayer2 = PhotonNetwork.Instantiate(playerPrefab.name, SpawnPoints[1].position, SpawnPoints[1].rotation);

            myPlayer1.AddComponent<SinglePlay>();
            myPlayer2.AddComponent<SinglePlay>();
            myPlayer2.GetComponent<SinglePlay>().Toggle();

            myPlayer1.GetComponent<RandomChef>().Send(0);
            myPlayer2.GetComponent<RandomChef>().Send(0);
        }
        else
        {
            int idx = Array.IndexOf(PhotonNetwork.PlayerList, PhotonNetwork.LocalPlayer);

            GameObject myPlayer = PhotonNetwork.Instantiate(playerPrefab.name, SpawnPoints[idx].position, SpawnPoints[idx].rotation);
            myPlayer.GetComponent<RandomChef>().Send(idx);

            //myPlayer.GetComponent<InputHandler>().enabled = true;
        }
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
        createDish.GenerateDish(); //���� Ÿ�̹�
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