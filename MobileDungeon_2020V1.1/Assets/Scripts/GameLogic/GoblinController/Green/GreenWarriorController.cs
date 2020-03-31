using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GreenWarriorController : GoblinMovementManager
{
    NavMeshAgent nav;
    Animator anim;
    GreenWarrior greenwarrior;

    void Start()
    {
        greenwarrior = new GreenWarrior(this.gameObject);
        nav = this.gameObject.GetComponent<NavMeshAgent>();
        anim = this.gameObject.GetComponent<Animator>();
        this.gameObject.GetComponent<GoblinHealthManager>().SetHealth(greenwarrior.GetHealth());
        this.gameObject.GetComponent<GoblinHealthManager>().SetDefense(greenwarrior.GetDefense());
    }
    void FixedUpdate()
    {     
        if (this.GetComponent<GoblinHealthManager>().GetHealth()>0)
        {
            this.Attack(anim, greenwarrior.GetAttackSpeed(), greenwarrior.GetDamage(), greenwarrior.GetCriticalDamage(), greenwarrior.GetCriticalPercentage(), 3);
            this.Chase(nav, anim, greenwarrior.GetMoveSpeeed());
            this.HangAround(anim, 25);
        }
        else
            this.StartCoroutine("Die");
    }
}
