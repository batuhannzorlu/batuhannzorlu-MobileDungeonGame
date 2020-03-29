using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RedBerserkerController : GoblinMovementManager
{

    NavMeshAgent nav;
    Animator anim;
    RedBerserker redberserker;

    void Start()
    {
        redberserker = new RedBerserker(this.gameObject);
        nav = this.gameObject.GetComponent<NavMeshAgent>();
        anim = this.gameObject.GetComponent<Animator>();

        // redwitchdoctor.GetVisionDistance();
    }
    void FixedUpdate()
    {
        this.Attack(anim, redberserker.GetAttackSpeed(), redberserker.GetDamage(), redberserker.GetCriticalDamage(), redberserker.GetCriticalPercentage(),3);
        this.Chase(nav, anim, redberserker.GetMoveSpeeed());
        this.HangAround(anim, 35);
    }
}
