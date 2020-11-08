using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;

public class PlayerPrefabsHandler : MonoBehaviourPunCallbacks
{
    [SerializeField] private GameObject playerModel;
    [SerializeField] private GameObject[] playerModelsPlaces;
    private GameObject[] activePlayerModels;
    private bool[] occupied;
    private int connectedPlayerCount = 0;
    // Start is called before the first frame update
    void Start()
    {
        occupied = new bool[3];
        activePlayerModels = new GameObject[3];
        PlayerJoinedLobby();
    }
    private void PlayerJoinedLobby()
    {
        activePlayerModels[GetPlayerLocationNumber()] = PhotonNetwork.Instantiate(playerModel.name, playerModelsPlaces[GetPlayerLocationNumber()].transform.position, playerModelsPlaces[GetPlayerLocationNumber()].transform.rotation);
    }

    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        base.OnPlayerLeftRoom(otherPlayer);
        leftGame(otherPlayer);
    }
    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        base.OnPlayerEnteredRoom(newPlayer);
    }
    public void leftGame(Player otherPlayer)
    {
        for (int i = 0; i < activePlayerModels.Length; i++)
        {
            if (activePlayerModels[i] != null && activePlayerModels[i].name == otherPlayer.NickName)
            {
                occupied[i] = false;
                activePlayerModels[i] = null;
                return;
            }
        }
    }
    public void ConnectedPlayerCountUp(GameObject player)
    {
        activePlayerModels[GetPlayerLocationNumber()] = player;
        occupied[GetPlayerLocationNumber()] = true;
        connectedPlayerCount++;
    }
    public Vector3 GetPosition(string name)
    {
        return playerModelsPlaces[GetPlayerLocationNumber()].transform.position;
    }
    public int GetPlayerLocationNumber()
    {
        for (int i = 0; i < occupied.Length; i++)
        {
            if (!occupied[i])
            {
                return i;
            }
        }
        return 0;
    }
    public int checkanimationNumber(GameObject playerObj)
    {
        for (int i = 0; i < occupied.Length; i++)
        {
            if(playerObj.name == activePlayerModels[i].name)
            {
                print("goeie animatie gevonden");
                return i;
            }
        }
        return 0;
    }

}
