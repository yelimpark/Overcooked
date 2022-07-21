using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class Invoker : MonoBehaviour
{
    public void Send(Command command)
    {
        PhotonView.Get(this).RPC("command.Execute", RpcTarget.All);
    }

    [PunRPC]
    public void ExecuteCommand(Command command)
    {
        command.Execute();
    }
}
