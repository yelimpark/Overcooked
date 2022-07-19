using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldScene : MonoBehaviour
{
    public Info stage1;
    public Info stage2;

    public ZoomIn ZoomInUI;
    public ZoomOut ZoomOutUI;

    public string loadScene;


    private SceneDefinition StageInfo;

    private void Start()
    {
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
            }
        }
    }
}
