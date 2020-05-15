using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class NetworkLobbyHook : NetworkRoomManager
{

    public override bool OnRoomServerSceneLoadedForPlayer(NetworkConnection conn, GameObject roomPlayer, GameObject gamePlayer)
    {
        SetupLocalPlayer ChoosenClass = gamePlayer.GetComponent<SetupLocalPlayer>();

        ChoosenClass.ChoosenClass = "SwordBerserker";
        Debug.Log("lobbbyyyyyyyyyyyyyyyyyyyyyyy");
        return base.OnRoomServerSceneLoadedForPlayer(conn, roomPlayer, gamePlayer);
    }
    //// Start is called before the first frame update
    //void Start()
    //{

    //}

    //// Update is called once per frame
    //void Update()
    //{

    //}
}
