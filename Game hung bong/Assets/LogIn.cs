using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using TMPro;

public class LogIn : MonoBehaviourPunCallbacks
{
    public TMP_InputField inputUsername;

    void Start()
    {
        this.inputUsername.text = "Sv1";
    }

    public virtual void Login()
    {
        string name = inputUsername.text;
        Debug.Log(transform.name + ": Login " + name);

        PhotonNetwork.AutomaticallySyncScene = true;
        PhotonNetwork.LocalPlayer.NickName = name;
        PhotonNetwork.ConnectUsingSettings();
    }
    public override void OnConnectedToMaster()
    {
        Debug.Log("OnConnectedToMaster");
        PhotonNetwork.JoinLobby();
    }

    public override void OnJoinedLobby()
    {
        Debug.Log("OnJoinedLobby");
    }
}
