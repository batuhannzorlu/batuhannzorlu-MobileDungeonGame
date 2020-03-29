//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using Mirror;

//public class NPowerUpController : NetworkBehaviour
//{
//    public GameObject PowerUpPrefab;
//    public GameObject PowerUpSpawn;
//    void Update()
//    {
//        //if (!isLocalPlayer) return;

//        if (Input.GetKeyDown("space"))
//        {
//            Debug.Log("girdi");
//            CreatePowerUp();
//        }
//    }

//    void CreatePowerUp()
//    {
//       GameObject newPowerUpPrefab= Instantiate(PowerUpPrefab, PowerUpSpawn.transform.position, PowerUpSpawn.transform.rotation);
//        newPowerUpPrefab.name = PowerUpPrefab.name;
//        RpcCreatePowerUp();
//    }
//    [ClientRpc]
//    void RpcCreatePowerUp()
//    {
//        if (!isServer)
//            CreatePowerUp();
//    }


//}
