using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using TMPro;
public class LogOut : MonoBehaviour
{
    public virtual void Logout()
    {
        Debug.Log(transform.name + ": Logout ");
        PhotonNetwork.Disconnect();
    }
}
