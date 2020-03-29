using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RedWarriorController : GoblinMovementManager
{
    NavMeshAgent nav;
    Animator anim;
    RedWarrior redwarrior;

    void Start()
    {
        redwarrior = new RedWarrior(this.gameObject);
        nav = this.gameObject.GetComponent<NavMeshAgent>();
        anim = this.gameObject.GetComponent<Animator>();

        // redwitchdoctor.GetVisionDistance();
    }
    void FixedUpdate()
    {
        this.Attack(anim, redwarrior.GetAttackSpeed(), redwarrior.GetDamage(), redwarrior.GetCriticalDamage(), redwarrior.GetCriticalPercentage(),3);
        this.Chase(nav, anim, redwarrior.GetMoveSpeeed());
        this.HangAround(anim, 35);
    }
}
