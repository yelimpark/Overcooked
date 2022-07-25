using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Info : MonoBehaviour
{
    public Animator animator;
    public bool onCollider = false;

    [Header("바뀔 Sprite")]
    public SpriteRenderer[] sprite = new SpriteRenderer[3]; 
    public Sprite YellowStar;

    [Header("바뀔 Materials")]
    public MeshRenderer FlagMesh;
    public Material[] Materials;

    [Header("스크립터블 정보")]
    public SceneDefinition sceneDefinition;

    public void Start()
    {
        if (!sceneDefinition)
        {
            return;
        }

        if(TitleSceneController.NewScene)
        {
            GameManager.Instance.DataManager.LoadNewStageData();
            TitleSceneController.NewScene = false;
        }
        else
        {
            GameManager.Instance.DataManager.LoadStageData();
        }
     


        for(int i = 0; i < GameManager.Instance.DataManager.currentStageInfo.Count; i++)
        {
            if(sceneDefinition.JsonIndex == GameManager.Instance.DataManager.currentStageInfo[i].Index)
            {
                for(int j = 0; j < sceneDefinition.StarScores.Length; j++)
                {
                    if(sceneDefinition.StarScores[j] < GameManager.Instance.DataManager.currentStageInfo[i].score)
                    {
                        sprite[j].sprite = YellowStar;
                        FlagMesh.material = Materials[j];
                    }
                }
                
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        onCollider = true;
        if (other.gameObject.CompareTag("Player"))
        {
            animator.SetBool("isEnter", true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        onCollider = false;
        if (other.gameObject.CompareTag("Player"))
        {
            animator.SetBool("isEnter", false);
        }
    }

}

