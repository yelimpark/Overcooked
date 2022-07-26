using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using KeyCode = System.String;
using Photon.Pun;

public class PoolingObject : MonoBehaviour
{
    public KeyCode key;
    public PoolingObject Clone(bool rpc = false)
    {

        //GameObject go = Instantiate(gameObject);
        //Debug.Log(gameObject.name);
        GameObject go = PhotonNetwork.Instantiate(gameObject.name, Vector3.zero, Quaternion.identity);

        PhotonView photonView = go.GetComponent<PhotonView>();
        if (rpc)
        {
            PhotonView.Get(this).RPC("InitSetting", RpcTarget.All, photonView.ViewID);
        }
        else
        {
            if (!go.TryGetComponent(out PoolingObject Mpo))
            {
                Mpo = go.AddComponent<PoolingObject>();
            }
            go.SetActive(false);
        }

        return go.GetComponent<PoolingObject>();
    }

    [PunRPC] 
    public void InitSetting(int idx)
    {
        GameObject go = PhotonView.Find(idx).gameObject;
        if (!go.TryGetComponent(out PoolingObject Mpo))
        {
            Mpo = go.AddComponent<PoolingObject>();
        }
        go.SetActive(false);
    }

    public GameObject GetGO()
    {
        GameObject go = Instantiate(gameObject);
        go.AddComponent<PoolingObject>();
        return go;
    }

    public void Activate() 
    {
       gameObject.SetActive(true);      
    }

    public void Disabled() 
    {
        gameObject.SetActive(false);
    }
}
