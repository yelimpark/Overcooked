using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldScene : MonoBehaviour
{
    [Header("껏다 킬 UI")]
    public GameObject FadeUI;

    [Header("깃발 정보")]
    public Info stage1;
    public Info stage2;

    [Header("검정화면 zoom In/Out")]
    public ZoomIn ZoomInUI;
    public ZoomOut ZoomOutUI;

    private void Start()
    {
        FadeUI.SetActive(true);
        ZoomInUI.ZoomInUI();

    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            if (stage1.onCollider)
            {
                Debug.Log("스테이지 1");

                GameVariable.SetDefinition(stage1.sceneDefinition);
                Debug.Log(GameVariable.GetDefinition().SceneName);
                ZoomOutUI.ZoomOutUI();
                //stage1.sceneDefinition.SceneName; 
            }
            else if (stage2.onCollider) 
            {
                Debug.Log("스테이지 2");

                GameVariable.SetDefinition(stage2.sceneDefinition);
                ZoomOutUI.ZoomOutUI();
            }
        }
    }
}
