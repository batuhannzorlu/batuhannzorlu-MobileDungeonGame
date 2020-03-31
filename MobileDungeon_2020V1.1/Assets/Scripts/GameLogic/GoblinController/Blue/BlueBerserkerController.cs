using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BlueBerserkerController : GoblinMovementManager
{
    NavMeshAgent nav;
    Animator anim;
    BlueBerserker blueberserker;

    void Start()
    {
        blueberserker = new BlueBerserker(this.gameObject);
        nav = this.gameObject.GetComponent<NavMeshAgent>();
        anim = this.gameObject.GetComponent<Animator>();
        this.gameObject.GetComponent<GoblinHealthManager>().SetHealth(blueberserker.GetHealth());
        this.gameObject.GetComponent<GoblinHealthManager>().SetDefense(blueberserker.GetDefense());
    }
    void FixedUpdate()
    {
        if (this.GetComponent<GoblinHealthManager>().GetHealth() > 0)
        {
            this.Attack(anim, blueberserker.GetAttackSpeed(), blueberserker.GetDamage(), blueberserker.GetCriticalDamage(), blueberserker.GetCriticalPercentage(), 3);
            this.Chase(nav, anim, blueberserker.GetMoveSpeeed());
            this.HangAround(anim, 25);
        }
        else
            this.StartCoroutine("Die");

    }
}
