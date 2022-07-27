using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class RandomChef : MonoBehaviour
{
    public List<GameObject> models = new List<GameObject>();

    public void Send(int idx)
    {
        PhotonView.Get(this).RPC("SetPlayer", RpcTarget.All, idx);
    }

    [PunRPC]
    public void SetPlayer(int idx)
    {
        models[idx].SetActive(true);
    }
}
