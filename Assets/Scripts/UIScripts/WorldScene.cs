using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class WorldScene : MonoBehaviour
{
    [Header("Van ��ġ")]
    public GameObject van;
    public GameObject Home;

    [Header("���� ų UI")]
    public GameObject FadeUI;

    [Header("��� ����")]
    public Info stage1;
    public Info stage2;

    [Header("����ȭ�� zoom In/Out")]
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
                Debug.Log("�������� 1");

                //PhotonView.Get(this).RPC("SetDefinition", RpcTarget.All);
                GameVariable.SetDefinition(stage1.sceneDefinition);

                //Debug.Log(GameVariable.GetDefinition().SceneName);

                //GameVariable.SetDefinition(stage1.sceneDefinition);

                //Debug.Log(GameVariable.GetDefinition().SceneName);
                ZoomOutUI.ZoomOutUI();
                //stage1.sceneDefinition.SceneName; 
            }
            else if (stage2.onCollider) 
            {
                Debug.Log("�������� 2");

                GameVariable.SetDefinition(stage2.sceneDefinition);
                ZoomOutUI.ZoomOutUI();
            }
        }
    }

    public void SelectSceneButton()
    {
        if (stage1.onCollider)
        {
            Debug.Log("�������� 1");

            //PhotonView.Get(this).RPC("SetDefinition", RpcTarget.All);
            GameVariable.SetDefinition(stage1.sceneDefinition);

            //Debug.Log(GameVariable.GetDefinition().SceneName);

            //GameVariable.SetDefinition(stage1.sceneDefinition);

            //Debug.Log(GameVariable.GetDefinition().SceneName);
            ZoomOutUI.ZoomOutUI();
            //stage1.sceneDefinition.SceneName; 
        }
        else if (stage2.onCollider)
        {
            Debug.Log("�������� 2");

            GameVariable.SetDefinition(stage2.sceneDefinition);
            ZoomOutUI.ZoomOutUI();
        }
    }

    [PunRPC]
    public void SetDefinition()
    {
        GameVariable.SetDefinition(stage1.sceneDefinition);
        ZoomOutUI.ZoomOutUI();
    }
}
