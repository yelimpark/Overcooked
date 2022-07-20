using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreController : MonoBehaviour
{
    public KitchenManager kitchenMgr;
    public Animator animator;
    public GameObject fever;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI tipText;
    public Color[] colors;

    public Transform spawnPos;
    public GameObject scoreString;

    private int score;
    private int feverLevel;

    private bool isFever = false;

    private void Update()
    {
        if (isFever && feverLevel == 4)
        {
            fever.SetActive(true);
            tipText.gameObject.SetActive(true);
        }
        else if (isFever)
        {
            fever.SetActive(false);
            tipText.gameObject.SetActive(true);
        }
        else
        {
            fever.SetActive(false);
            tipText.gameObject.SetActive(false);
        }
    }

    public void GetScore(int score, bool isFever, int feverLevel)
    {
        this.isFever = isFever;
        tipText.SetText($"фа x {feverLevel}");

        this.score += score;
        scoreText.SetText($"{this.score}");

        var str = Instantiate(scoreString, spawnPos);
        var go = str.GetComponent<TextMeshProUGUI>();
        go.SetText($"+{score}");
        go.color = colors[0];
    }
}
