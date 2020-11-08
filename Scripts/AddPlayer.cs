using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class AddPlayer : MonoBehaviourPunCallbacks
{
    [SerializeField] private string playerModelHandlerName = "PlayerLobbyHandler";
    private PlayerPrefabsHandler playerPrefabsHandler;
    [SerializeField] private TextMesh text;
    [SerializeField] private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.name = gameObject.GetComponent<PhotonView>().Owner.NickName;
        playerPrefabsHandler = GameObject.Find("PlayerLobbyHandler").GetComponent<PlayerPrefabsHandler>();
        transform.position = playerPrefabsHandler.GetPosition(gameObject.GetComponent<PhotonView>().Owner.NickName);
        text.text = gameObject.GetComponent<PhotonView>().Owner.NickName;
        playerPrefabsHandler.ConnectedPlayerCountUp(gameObject);
        anim.SetInteger("PlacementNumber", playerPrefabsHandler.checkanimationNumber(gameObject) + 1);
    }
}
