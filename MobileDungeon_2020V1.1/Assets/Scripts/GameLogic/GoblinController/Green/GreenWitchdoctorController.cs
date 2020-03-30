using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GreenWitchdoctorController : GoblinMovementManager
{
    NavMeshAgent nav;
    Animator anim;
    GreenWitchdoctor greenWitchdoctor;

    void Start()
    {
        greenWitchdoctor = new GreenWitchdoctor(this.gameObject);
        nav = this.gameObject.GetComponent<NavMeshAgent>();
        anim = this.gameObject.GetComponent<Animator>();
        this.gameObject.GetComponent<GoblinHealthManager>().SetHealth(greenWitchdoctor.GetHealth());
        this.gameObject.GetComponent<GoblinHealthManager>().SetDefense(greenWitchdoctor.GetDefense());
    }
    void FixedUpdate()
    {
        this.Attack(anim, greenWitchdoctor.GetAttackSpeed(), greenWitchdoctor.GetDamage(), greenWitchdoctor.GetCriticalDamage(), greenWitchdoctor.GetCriticalPercentage(), 3);
        this.Chase(nav, anim, greenWitchdoctor.GetMoveSpeeed());
        this.HangAround(anim, 25);
    }
}
