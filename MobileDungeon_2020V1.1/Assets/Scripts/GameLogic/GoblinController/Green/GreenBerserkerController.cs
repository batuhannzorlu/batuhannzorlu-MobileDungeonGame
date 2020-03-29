using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GreenBerserkerController : GoblinMovementManager
{
    NavMeshAgent nav;
    Animator anim;
    GreenBerserker greenberserker;

    void Start()
    {
        greenberserker = new GreenBerserker(this.gameObject);
        nav = this.gameObject.GetComponent<NavMeshAgent>();
        anim = this.gameObject.GetComponent<Animator>();
    }
    void FixedUpdate()
    {
        this.Attack(anim, greenberserker.GetAttackSpeed(), greenberserker.GetDamage(), greenberserker.GetCriticalDamage(), greenberserker.GetCriticalPercentage(),3);
        this.Chase(nav, anim, greenberserker.GetMoveSpeeed());
        this.HangAround(anim, 15);
    }
}
