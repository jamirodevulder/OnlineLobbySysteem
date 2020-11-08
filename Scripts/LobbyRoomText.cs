using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;

public class LobbyRoomText : MonoBehaviour
{
    [SerializeField] private Text LobbyName;
    // Start is called before the first frame update
    void Start()
    {
        LobbyName.text = "Lobby: Room(" + PhotonNetwork.CurrentRoom.Name.Substring(0, 5) + ")";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
