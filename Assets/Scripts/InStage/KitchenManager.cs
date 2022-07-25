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
