using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BlueWarriorController : GoblinMovementManager
{
    NavMeshAgent nav;
    Animator anim;
    BlueWarrior bluewarrior;

    void Start()
    {
        bluewarrior = new BlueWarrior(this.gameObject);
        nav = this.gameObject.GetComponent<NavMeshAgent>();
        anim = this.gameObject.GetComponent<Animator>();
    }
    void FixedUpdate()
    {
        this.Attack(anim, bluewarrior.GetAttackSpeed(), bluewarrior.GetDamage(), bluewarrior.GetCriticalDamage(), bluewarrior.GetCriticalPercentage(),3);
        this.Chase(nav, anim, bluewarrior.GetMoveSpeeed());
        this.HangAround(anim, 25);
    }
}
