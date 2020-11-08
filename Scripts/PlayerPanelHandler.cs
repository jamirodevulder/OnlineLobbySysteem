using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;
public class PlayerPanelHandler : MonoBehaviourPunCallbacks
{
    [SerializeField] private string playersLobbyHandlerName;
    private GameObject playersLobbyHandler;
    private PlayerLobbyBoard playerLobbyBoard;
    // Start is called before the first frame update
    void Start()
    {
        SetVariables();
        SetPlayerPlane();
    }
    
    private void SetVariables()
    {
        playersLobbyHandler = GameObject.Find(playersLobbyHandlerName);
        playerLobbyBoard = playersLobbyHandler.GetComponent<PlayerLobbyBoard>();
    }
    private void SetPlayerPlane()
    {
        transform.parent = playersLobbyHandler.transform;
        gameObject.name = gameObject.GetComponent<PhotonView>().Owner.NickName;
        gameObject.transform.localPosition = playerLobbyBoard.GetPlayerBoardPosition(gameObject);
        playerLobbyBoard.AddPlayerCount();
        if (PhotonNetwork.LocalPlayer.NickName != gameObject.GetComponent<PhotonView>().Owner.NickName)
        {
            gameObject.GetComponentInChildren<Text>().text = gameObject.GetComponent<PhotonView>().Owner.NickName;
        }
        else
        {
            gameObject.GetComponentInChildren<Text>().text = gameObject.GetComponent<PhotonView>().Owner.NickName + " (YOU)";
        }
    }
}
