using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using TMPro;
using UnityEngine.UI;

public class PhotonTest : MonoBehaviourPunCallbacks
{
    private string gameVersion = "0.0.1";

    public TMP_InputField nameInput;
    public TMP_InputField roomNumInput;

    public GameObject joinGame;
    public InvitePopUp popUp;
    public GameObject InRoomCanvas;

    public TextMeshProUGUI playerList;

    public Button createBtn;
    public Button connectBtn;

    public GameObject WorldBtn;

    PhotonView photonView;

    public List<string> players = new List<string>();

    private void Start()
    {
        photonView = PhotonView.Get(this);
        PhotonNetwork.GameVersion = gameVersion;
        PhotonNetwork.ConnectUsingSettings();
        PhotonNetwork.AutomaticallySyncScene = true;
        createBtn.enabled = false;
        connectBtn.enabled = false;
    }

    public override void OnConnectedToMaster()
    {
        PhotonNetwork.JoinLobby();
        createBtn.enabled = true;
        connectBtn.enabled = true;
    }

    public override void OnDisconnected(DisconnectCause cause)
    {
        PhotonNetwork.ConnectUsingSettings();
    }

    public void Connect()
    {
        PhotonNetwork.NickName = nameInput.text;
        PhotonNetwork.JoinRoom(roomNumInput.text);
        joinGame.SetActive(false);
    }

    public void OnCreateBtn()
    {
        PhotonNetwork.NickName = nameInput.text;
        int roomNum = Random.Range(0, 1000000);
        string roomNumStr = roomNum.ToString();
        
        popUp.SetCode(roomNumStr);
        PhotonNetwork.CreateRoom(roomNumStr);
        
        popUp.gameObject.SetActive(true);
        joinGame.SetActive(false);
        WorldBtn.SetActive(true);
    }

    public override void OnJoinedRoom()
    {
        InRoomCanvas.SetActive(true);
        photonView.RPC("AddPlayerList", RpcTarget.AllBuffered, PhotonNetwork.NickName);
    }

    [PunRPC]
    public void AddPlayerList(string name)
    {
        players.Add(name);
        string names = "";
        foreach (string player in players)
        {
            names += $"{player}\n";
        }
        playerList.text = names;
    }

    public override void OnLeftRoom()
    {
        InRoomCanvas.SetActive(false);
        joinGame.SetActive(true);
        photonView.RPC("RemovePlayerList", RpcTarget.AllBuffered, PhotonNetwork.NickName);
    }

    [PunRPC]
    public void RemovePlayerList(string name)
    {
        players.Remove(name);
        string names = "";
        foreach (string player in players)
        {
            names += $"{player}\n";
        }
        playerList.text = names;
    }

    public void MoveToWorldMap()
    {
        PhotonNetwork.LoadLevel("WorldScene 1");
    }
}
