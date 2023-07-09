using Photon.Pun;
using Photon.Realtime;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PhotonRoom : MonoBehaviourPunCallbacks
{
    public TMP_InputField input;
    public UIRoomProfile roomPrefab;
    public List<RoomInfo> updatedRooms;
    public List<RoomProfile> rooms = new List<RoomProfile>();

    private void Start()
    {
        this.input.text = "Room1";
    }

    public virtual void Create()
    {
        string name = input.text;
        Debug.Log(transform.name + ": Create Room " + name);
        PhotonNetwork.CreateRoom(name);
    }

    public virtual void Join()
    {
        string name = input.text;
        Debug.Log(transform.name + ": Join Room " + name);
        PhotonNetwork.JoinRoom(name);
    }

    public virtual void Leave()
    {
        Debug.Log(transform.name + ": Leave Room");
        PhotonNetwork.LeaveRoom();
    }

    public virtual void StartGame()
    {
        Debug.Log(transform.name + ": Start Game");
        // if (PhotonNetwork.IsMasterClient) PhotonNetwork.LoadLevel("New Scene");
        // else Debug.LogWarning("You are not Master Client");

        PhotonNetwork.LoadLevel("New Scene");
    }

    public override void OnCreatedRoom()
    {
        Debug.Log("OnCreatedRoom");
    }

    public override void OnJoinedRoom()
    {
        Debug.Log("OnJoinedRoom");
        this.StartGame();
    }

    public override void OnLeftRoom()
    {
        Debug.Log("OnLeftRoom");
    }

    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        Debug.Log("OnCreateRoomFailed: " + message);
    }

    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        Debug.Log("OnRoomListUpdate");
        this.updatedRooms = roomList;

        foreach (RoomInfo roomInfo in roomList)
        {
            if (roomInfo.RemovedFromList) this.RoomRemove(roomInfo);
            else this.RoomAdd(roomInfo);
        }

        this.UpdateRoomProfileUI();
    }

    protected virtual void RoomAdd(RoomInfo roomInfo)
    {
        RoomProfile roomProfile;

        roomProfile = this.RoomByName(roomInfo.Name);
        if (roomProfile != null) return;

        roomProfile = new RoomProfile
        {
            name = roomInfo.Name
        };
        this.rooms.Add(roomProfile);

    }

    protected virtual void UpdateRoomProfileUI()
    {

        foreach (RoomProfile roomProfile in this.rooms)
        {
            UIRoomProfile uiRoomProfile = Instantiate(this.roomPrefab);
            uiRoomProfile.SetRoomProfile(roomProfile);
        }
    }

    protected virtual void RoomRemove(RoomInfo roomInfo)
    {
        RoomProfile roomProfile = this.RoomByName(roomInfo.Name);
        if (roomProfile == null) return;
        this.rooms.Remove(roomProfile);
    }

    protected virtual RoomProfile RoomByName(string name)
    {
        foreach (RoomProfile roomProfile in this.rooms)
        {
            if (roomProfile.name == name) return roomProfile;
        }
        return null;
    }
}
