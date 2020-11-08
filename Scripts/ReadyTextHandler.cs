using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;

public class ReadyTextHandler : MonoBehaviourPun
{
    [SerializeField] private Text readyAmountText;
    [SerializeField] private PlayerLobbyBoard playerLobbyBoard;
    void Update()
    {
        readyAmountText.text = "ready " + CheckForReadyUps().ToString() +  "/" + PhotonNetwork.CurrentRoom.PlayerCount;
    }
    private int CheckForReadyUps()
    {
        GameObject[] players = playerLobbyBoard.GetPlayers();
        int readyPlayers = 0;
        for(int i = 0; i < players.Length; i++)
        {
            if(players[i] != null)
            {
                if(players[i].GetComponentInChildren<ReadyUp>().GetIAmReady())
                    readyPlayers++;
            }
        }
        return readyPlayers;
    }
}
