using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BlueWitchdoctorController : GoblinMovementManager
{
    NavMeshAgent nav;
    Animator anim;
    BlueWitchdoctor bluewitchdoctor;

    void Start()
    {
        bluewitchdoctor = new BlueWitchdoctor(this.gameObject);
        nav = this.gameObject.GetComponent<NavMeshAgent>();
        anim = this.gameObject.GetComponent<Animator>();
        this.gameObject.GetComponent<GoblinHealthManager>().SetHealth(bluewitchdoctor.GetHealth());
        this.gameObject.GetComponent<GoblinHealthManager>().SetDefense(bluewitchdoctor.GetDefense());
    }
    void FixedUpdate()
    {
        if (this.GetComponent<GoblinHealthManager>().GetHealth() > 0)
        {
            this.Attack(anim, bluewitchdoctor.GetAttackSpeed(), bluewitchdoctor.GetDamage(), bluewitchdoctor.GetCriticalDamage(), bluewitchdoctor.GetCriticalPercentage(), 13);
            this.Chase(nav, anim, bluewitchdoctor.GetMoveSpeeed());
            this.HangAround(anim, 25);
        }
        else
            this.StartCoroutine("Die");

    }
}
