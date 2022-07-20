using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KitchenManager : MonoBehaviour
{
    // UI 
    public CardManager cm;
    public ScoreController scoreCtr;

    public int score;
    public int tipScore;
    public int successSubmit;
    public int failSubmit;

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
            feverLevel++;
            if (feverLevel > 4)
            {
                feverLevel = 4;
            }
            var tip = (int)(score * 0.1f) * feverLevel;
            tipScore += tip;
            result += tip;
        }
        else
        {
            feverLevel = 0;
        }
        successSubmit++;
        scoreCtr.GetScore(result, isFever, feverLevel);
    }
}
