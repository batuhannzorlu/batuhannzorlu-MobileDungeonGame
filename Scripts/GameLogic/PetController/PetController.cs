using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using UnityEngine.AI;

public class PetController : NetworkBehaviour
{
    public GameObject _pet;
    private NavMeshAgent nav;

    void Start()
    {
        GameObject newPet = Instantiate(_pet, this.transform.position, Quaternion.identity, null) as GameObject;
        newPet.name = _pet.name;
        nav = newPet.gameObject.GetComponent<NavMeshAgent>();
    }
    void Update()
    {
        if (isLocalPlayer)
            CmdChase();

    }


    [ClientRpc]
    public void RpcChase()
    {
        if (nav.isOnNavMesh)
        {
            if (!isServer)
                nav.SetDestination(this.transform.position);
        }
    }
    [Command]
    public void CmdChase()
    {
        if (nav.isOnNavMesh)
        {
            nav.SetDestination(this.transform.position);
        }
        RpcChase();
    }

    public void HangAround()
    {

    }
}
