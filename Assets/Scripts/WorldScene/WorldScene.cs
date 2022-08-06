using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.SceneManagement;

public class WorldScene : MonoBehaviour
{
    [Header("Van ��ġ")]
    public GameObject van;
    public GameObject Home;

    [Header("���� ų UI")]
    public GameObject FadeUI;

    [Header("��� ����")]
    public ToMain back;
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
            SelectSceneButton();
        }
    }

    public void SelectSceneButton()
    {
        if (stage1.onCollider)
        {
            //PhotonView.Get(this).RPC("SetDefinition", RpcTarget.All);
            GameVariable.SetDefinition(stage1.sceneDefinition);

            //Debug.Log(GameVariable.GetDefinition().SceneName);
            ZoomOutUI.ZoomOutUI();
        }
        else if (stage2.onCollider)
        {
            GameVariable.SetDefinition(stage2.sceneDefinition);
            ZoomOutUI.ZoomOutUI();
        }
        else if (back.onCollider)
        {
            SceneManager.LoadScene("TitleScene");
        }
    }

    [PunRPC]
    public void SetDefinition()
    {
        GameVariable.SetDefinition(stage1.sceneDefinition);
        ZoomOutUI.ZoomOutUI();
    }
}
