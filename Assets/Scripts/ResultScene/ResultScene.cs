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
    public int successSubmit;
    public int failSubmit;
    public int totalScore;

    [Header("�� �ٲ� Sprite")]
    public Image[] sprite = new Image[3];
    public Sprite YellowStar;


    private void Start()
    {
        TitleText.text = GameVariable.GetDefinition().SceneName;
        
        score = GameManager.Instance.DataManager.currentStageInfo[GameVariable.GetDefinition().JsonIndex].score;
        tipScore = GameManager.Instance.DataManager.currentStageInfo[GameVariable.GetDefinition().JsonIndex].tipScore;
        lostScore = GameManager.Instance.DataManager.currentStageInfo[GameVariable.GetDefinition().JsonIndex].lostScore;
        failSubmit = GameManager.Instance.DataManager.currentStageInfo[GameVariable.GetDefinition().JsonIndex].failSubmit;
        successSubmit = GameManager.Instance.DataManager.currentStageInfo[GameVariable.GetDefinition().JsonIndex].successSubmit;
        totalScore = GameManager.Instance.DataManager.currentStageInfo[GameVariable.GetDefinition().JsonIndex].totalScore;

        

        ScoreText.text = score.ToString();
        TipScoreText.text = tipScore.ToString();
        lostScoreText.text = lostScore.ToString();

        SubMissionCountText.text = $"��޵� �ֹ� x {successSubmit.ToString()}";
        FailedMissionCountText.text = $"������ �ֹ� x {failSubmit.ToString()}";


        TotalScoreText.text = totalScore.ToString();

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
#if UNITY_STANDALONE
        if(Input.GetKeyDown(KeyCode.Space))
#endif
#if UNITY_ANDROID
        if(Input.anyKey)
#endif
        {
            if (totalScore > GameManager.Instance.DataManager.currentStageInfo[GameVariable.GetDefinition().JsonIndex].totalScore)
            {
                GameManager.Instance.DataManager.currentStageInfo[GameVariable.GetDefinition().JsonIndex].totalScore = totalScore;
                GameManager.Instance.DataManager.currentStageInfo[GameVariable.GetDefinition().JsonIndex].failSubmit = failSubmit;
                GameManager.Instance.DataManager.currentStageInfo[GameVariable.GetDefinition().JsonIndex].successSubmit = successSubmit;
                GameManager.Instance.DataManager.currentStageInfo[GameVariable.GetDefinition().JsonIndex].score = score;
                GameManager.Instance.DataManager.currentStageInfo[GameVariable.GetDefinition().JsonIndex].tipScore = tipScore;
                GameManager.Instance.DataManager.currentStageInfo[GameVariable.GetDefinition().JsonIndex].lostScore = lostScore;
            }
            GameManager.Instance.DataManager.SaveStageData();
            ZoomOutUI.ZoomOutUI();
        }
    }
}
