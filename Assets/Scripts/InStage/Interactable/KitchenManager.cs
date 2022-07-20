using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KitchenManager : MonoBehaviour
{
    // UI 
    public CardManager cm;
    public ScoreController scoreCtr;

    public int successSubmit;
    public int score;
    public int tipScore;
    public int failSubmit;
    public int lostScore;

    private int feverLevel;

    public void OnSubmit(GameObject go)
    {
        cm.OnSubmit(go);
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

    public void LostScore(int lostScore)
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
