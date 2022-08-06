#define MULTI

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
    public Button newGame;
    public Button LoadGame;

    public TextMeshProUGUI nameFieldLabel;
    public TextMeshProUGUI roomNumberFieldLabel;

    public List<string> players = new List<string>();

    public AudioSource pressButtonSound;

    private void Start()
    {
        if (PhotonNetwork.InRoom)
        {
            joinGame.SetActive(false);
            InRoomCanvas.SetActive(true);

            string playerStr = string.Empty;
            foreach(var player in PhotonNetwork.PlayerList)
            {
                playerStr += $"{player}\n";
            }

            playerList.text = playerStr;

            return;
        }

        PhotonNetwork.GameVersion = gameVersion;
        PhotonNetwork.ConnectUsingSettings();
        PhotonNetwork.AutomaticallySyncScene = true;
        createBtn.enabled = false;
        connectBtn.enabled = false;
        newGame.enabled = false;
        LoadGame.enabled = false;
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
        if (nameInput.text == null || nameInput.text == string.Empty)
        {
            nameFieldLabel.color = Color.red;
            StartCoroutine(CoColorWhite(nameFieldLabel));
            return;
        }

        if (roomNumInput.text == null || roomNumInput.text == string.Empty)
        {
            roomNumberFieldLabel.color = Color.red;
            StartCoroutine(CoColorWhite(roomNumberFieldLabel));
            return;
        }

        pressButtonSound.Play();
        PhotonNetwork.NickName = nameInput.text;
        PhotonNetwork.JoinRoom(roomNumInput.text);
        joinGame.SetActive(false);
    }

    public void OnCreateBtn()
    {
        if (nameInput.text == null || nameInput.text == string.Empty)
        {
            nameFieldLabel.color = Color.red;
            StartCoroutine(CoColorWhite(nameFieldLabel));
            return;
        }

        pressButtonSound.Play();
        PhotonNetwork.NickName = nameInput.text;
        int roomNum = Random.Range(0, 1000000);
        string roomNumStr = roomNum.ToString();
        
        popUp.SetCode(roomNumStr);
        PhotonNetwork.CreateRoom(roomNumStr);
        
        popUp.gameObject.SetActive(true);
        joinGame.SetActive(false);
    }

    public override void OnJoinedRoom()
    {
        newGame.enabled = true;
        LoadGame.enabled = true;
        InRoomCanvas.SetActive(true);
        PhotonView.Get(this).RPC("AddPlayerList", RpcTarget.AllBuffered, PhotonNetwork.NickName);
    }

    public override void OnJoinRoomFailed(short returnCode, string message)
    {
        base.OnJoinRoomFailed(returnCode, message);

        switch (returnCode)
        {
            case 32758:
                roomNumberFieldLabel.color = Color.red;
                StartCoroutine(CoColorWhite(roomNumberFieldLabel));
                return;
        }
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
        PhotonView.Get(this).RPC("RemovePlayerList", RpcTarget.AllBuffered, PhotonNetwork.NickName);
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
        PhotonNetwork.LoadLevel("WorldScene");
    }

    IEnumerator CoColorWhite(TextMeshProUGUI target)
    {
        yield return new WaitForSeconds(1f);

        target.color = Color.white;
    }
}
