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


    public Transform FirePosition;
    public GameObject FirePrefab;
    BoxCollider Weapon;


    public void Chase(NavMeshAgent nav, Animator anim, float _MoveSpeed)
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
    public void Attack(Animator anim, float _AttackSpeed, float _Damage, float _CriticalDamage, float _CriticalPercentage, float _AttackRange)
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
    public void HangAround(Animator anim, float _VisionDistance)
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
    public IEnumerator Die()
    {
        if (this.GetComponent<GoblinHealthManager>().GetHealth() <= 0)
        {
            this.GetComponent<Animator>().Play("Death_1");
            yield return new WaitForSeconds(3);
            transform.Translate(-Vector3.up * Time.deltaTime / 3);
            yield return new WaitForSeconds(4);            
            Destroy(this.gameObject);
        }
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


    /// <summary>
    // ANIMATION EVENTS
    /// </summary>
    //BERSERKER-WARRIOR ATTACK 
    private void OnBeginAttack()
    {
        Weapon = this.GetComponentInChildren<BoxCollider>();
        Weapon.enabled = true;
    }
    private void OnEndAttack()
    {
        Weapon = this.GetComponentInChildren<BoxCollider>();
        Weapon.enabled = false;
    }

    //WITCHDOCTOR ATTACK
    private void CreateFire()
    {
        GameObject _Fire = Instantiate(FirePrefab, FirePosition.transform.position, FirePosition.transform.rotation);
        _Fire.gameObject.GetComponent<Rigidbody>().AddForce((this.transform.forward + new Vector3(0, 0.1f, 0)) * 500);
    }




}
