using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;
using UnityEngine.UIElements;
using UnityEditor;
using System;

public class PlayerLobbyBoard : MonoBehaviourPunCallbacks
{
    [SerializeField] private GameObject playerPannel;
    private GameObject[] players;
    [SerializeField] private int playerMax;
    [SerializeField] private Transform[] places;
    private PhotonView view;
    private int playerCount = 0;
    private int readyCount = 0;
    [SerializeField] private string tagName;
    // Start is called before the first frame update
    void Start()
    {
        players = new GameObject[playerMax];
        view = GetComponent<PhotonView>();
        PlayerJoinedLobby();
    }

    // Update is called once per frame

    private void PlayerJoinedLobby()
    {
        PhotonNetwork.Instantiate(playerPannel.name, new Vector3(0, 0, 0), Quaternion.identity);
    }
    public Vector3 GetPlayerBoardPosition(GameObject playerObject)
    {
        players[playerCount] = playerObject;
        return places[playerCount].localPosition;
    }
    public void AddPlayerCount()
    {
        playerCount++;
    }
    public void setReady()
    {
        GameObject[] gameObjectsWitUItag = GameObject.FindGameObjectsWithTag(tagName);
        for(int i = 0; i < gameObjectsWitUItag.Length; i++)
        {
            if(gameObjectsWitUItag[i].name == PhotonNetwork.LocalPlayer.NickName)
            {
                gameObjectsWitUItag[i].GetComponentInChildren<ReadyUp>().ButtonReadyUp();
                return;
            }
        }
       
    }
    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        base.OnPlayerLeftRoom(otherPlayer);
        CleanPlayerLobby(otherPlayer);
    }
    private void CleanPlayerLobby(Player otherPlayer)
    {
        int placeCount = 0;
        for (int i = 0; i < players.Length; i++)
        {
            if (players[i] != null && players[i].name == otherPlayer.NickName)
            {
                players[i] = null;
            }
        }
        playerCount--;
        for (int i = 0; i < players.Length; i++)
        {
            if (players[i] != null)
            {
                players[i].transform.localPosition = places[placeCount].localPosition;
                placeCount++;
            }
        }
    }
    public GameObject[] GetPlayers()
    {
        return players;
    }

}
