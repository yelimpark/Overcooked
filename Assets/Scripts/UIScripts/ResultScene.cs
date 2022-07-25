using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ResultScene : MonoBehaviour
{
    [Header("���� ų UI")] 
    public GameObject ZoomUI;
    public ZoomOut ZoomOutUI;
    
    [Header("�޾ƿ� Text")]
    public TextMeshProUGUI TitleText;                   //����
    public TextMeshProUGUI ScoreText;                   //������
    public TextMeshProUGUI TipScoreText;                //�� ����
    public TextMeshProUGUI lostScoreText;               //���� ����
    public TextMeshProUGUI TotalScoreText;              //�� ����
    public TextMeshProUGUI SubMissionCountText;         //������ ����
    public TextMeshProUGUI FailedMissionCountText;      //������ ����

    [Header("������")]
    public int score;
    public int tipScore;
    public int lostScore;
    public int totalScore;

    [Header("�� �ٲ� Sprite")]
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

        SubMissionCountText.text = $"��޵� �ֹ� x {GameManager.Instance.KitchenManager.SuccessSubmit.ToString()}";
        FailedMissionCountText.text = $"������ �ֹ� x {GameManager.Instance.KitchenManager.FailSubmit.ToString()}";


        TotalScoreText.text = (score + tipScore - lostScore).ToString();

        //ù��°, �ι���, ����° ��Ÿ ���ھ�� totalScore �� ���ؼ� ���� sprite�� �ٲ�����.
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
