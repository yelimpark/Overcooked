using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ResultScene : MonoBehaviour
{
    [Header("끄고 킬 UI")] 
    public GameObject ZoomUI;
    public ZoomOut ZoomOutUI;
    
    [Header("받아올 Text")]
    public TextMeshProUGUI TitleText;                   //제목
    public TextMeshProUGUI ScoreText;                   //점수들
    public TextMeshProUGUI TipScoreText;                //팁 점수
    public TextMeshProUGUI lostScoreText;               //실패 점수
    public TextMeshProUGUI TotalScoreText;              //총 점수
    public TextMeshProUGUI SubMissionCountText;         //성공한 갯수
    public TextMeshProUGUI FailedMissionCountText;      //실패한 갯수

    [Header("점수들")]
    public int score;
    public int tipScore;
    public int lostScore;
    public int totalScore;

    [Header("별 바뀔 Sprite")]
    public Image[] sprite = new Image[3];
    public Sprite YellowStar;


    private void Start()
    {
        TitleText.text = GameVariable.GetDefinition().SceneName;
        
        score = GameManager.Instance.KitchenManager.Score;
        tipScore = GameManager.Instance.KitchenManager.TipScore;
        lostScore = GameManager.Instance.KitchenManager.LostScore;

        totalScore = score + tipScore - lostScore;

        if(totalScore > GameManager.Instance.DataManager.currentStageInfo[GameVariable.GetDefinition().JsonIndex].score)
        {
            GameManager.Instance.DataManager.currentStageInfo[GameVariable.GetDefinition().JsonIndex].score = totalScore;
        }

        ScoreText.text = GameManager.Instance.KitchenManager.Score.ToString();
        TipScoreText.text = GameManager.Instance.KitchenManager.TipScore.ToString();
        lostScoreText.text = GameManager.Instance.KitchenManager.LostScore.ToString();

        SubMissionCountText.text = $"배달된 주문 x {GameManager.Instance.KitchenManager.SuccessSubmit.ToString()}";
        FailedMissionCountText.text = $"실패한 주문 x {GameManager.Instance.KitchenManager.FailSubmit.ToString()}";


        TotalScoreText.text = (score + tipScore - lostScore).ToString();

        //첫번째, 두번쨰, 세번째 스타 스코어와 totalScore 를 비교해서 별의 sprite를 바꿔주자.
        for (int i = 0; i < GameVariable.GetDefinition().StarScores.Length; i++)
        {
            if(GameVariable.GetDefinition().StarScores[i] < totalScore)
            {
                sprite[i].sprite = YellowStar;
            }

        }

    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            GameManager.Instance.DataManager.SaveStageData();
            ZoomOutUI.ZoomOutUI();
        }
    }
}
