using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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
        //int idx = Array.IndexOf(PhotonNetwork.PlayerList, PhotonNetwork.LocalPlayer);

        //GameObject myPlayer = PhotonNetwork.Instantiate(playerPrefab.name, SpawnPoints[idx].position, SpawnPoints[idx].rotation);
        //myPlayer.GetComponent<InputHandler>().enabled = true;
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
