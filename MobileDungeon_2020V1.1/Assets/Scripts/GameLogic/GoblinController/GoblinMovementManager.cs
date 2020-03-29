using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using UnityEngine.AI;

public class GoblinMovementManager : NetworkBehaviour
{
    private int ReferencePlayer;    
    protected float VisionDistance = 35;

    protected bool IsPlayerInAttackRange = false;
    protected bool IsPlayerInHangOutRange = false;
    protected float AttackRange = 3;

    public void Chase(NavMeshAgent nav, Animator anim,float _MoveSpeed)
    {
        FindReferencePlayer();
        if (GameManager.Players[ReferencePlayer] == null) return;
        if (!IsPlayerInAttackRange && !IsPlayerInHangOutRange)
        {
            nav.enabled = true;
            if (nav.isOnNavMesh)
            {
                nav.SetDestination(GameManager.Players[ReferencePlayer].transform.position);
                anim.SetTrigger("Run_1");
            }
        }
        else
            nav.enabled = false;
    }
    public void Attack(Animator anim,float _AttackSpeed,float _Damage,float _CriticalDamage,float _CriticalPercentage,float _AttackRange)
    {
        Vector3 relativePos;
        FindReferencePlayer();
        if (GameManager.Players[ReferencePlayer] == null) return;
        if (Vector3.Distance(GameManager.Players[ReferencePlayer].transform.position, this.transform.position) < _AttackRange)
        {
            IsPlayerInAttackRange = true;
            relativePos = GameManager.Players[ReferencePlayer].transform.position - transform.position;
            Quaternion rotation = Quaternion.LookRotation(relativePos);
            transform.rotation = rotation;
            anim.SetTrigger("Attack_1");
        }
        else
            IsPlayerInAttackRange = false;

    }
    public void HangAround(Animator anim,float _VisionDistance)
    {
        FindReferencePlayer();
        if (GameManager.Players[ReferencePlayer] == null) return;
        if (Vector3.Distance(GameManager.Players[ReferencePlayer].transform.position, this.transform.position) >= _VisionDistance)
        {
            IsPlayerInHangOutRange = true;
            anim.SetTrigger("Idle_1");
        }
        else
            IsPlayerInHangOutRange = false;
    }
    protected void FindReferencePlayer()
    {
        Vector3 mindistance = new Vector3();
        if (GameManager.Players[0] == null) return;
        mindistance = GameManager.Players[0].transform.position - this.transform.position;
        for (int i = 0; i < GameManager.Players.Count; i++)
        {
            if (GameManager.Players[i] == null) return;
            Vector3 tempdistance = GameManager.Players[i].transform.position - this.transform.position;
            if (tempdistance.magnitude <= mindistance.magnitude)
            {
                mindistance = tempdistance;
                ReferencePlayer = i;
            }
        }
    }
}
