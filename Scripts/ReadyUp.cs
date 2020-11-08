using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;

public class ReadyUp : MonoBehaviourPun, IPunObservable
{
    [SerializeField] private string playersLobbyHandlerName;
    [SerializeField] private Color ready;
    [SerializeField] private Color notReady;
    [SerializeField] private Image thisImage;
    private PlayerLobbyBoard playerLobbyBoard;
    private PhotonView viewer;
    private bool iAmReady = false;
    public string test;
    
    void Start()
    {
        viewer = GetComponentInParent<PhotonView>();
        playerLobbyBoard = GameObject.Find(playersLobbyHandlerName).GetComponent<PlayerLobbyBoard>();
    }
    void Update()
    {
        if(iAmReady)
        {
            thisImage.color = ready;
        }
        else
        {
            thisImage.color = notReady;
        }
    }
    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            stream.SendNext(iAmReady);
        }
        else
        {
            iAmReady = (bool)stream.ReceiveNext();
        }
    }

    public void ButtonReadyUp()
    {
        if(PhotonNetwork.LocalPlayer.NickName == viewer.Owner.NickName)
        {
            if(iAmReady)
            {
                iAmReady = false;
            }
            else
            {
                iAmReady = true;

            }
        }
    }
    public bool GetIAmReady()
    {
        return iAmReady;
    }
}