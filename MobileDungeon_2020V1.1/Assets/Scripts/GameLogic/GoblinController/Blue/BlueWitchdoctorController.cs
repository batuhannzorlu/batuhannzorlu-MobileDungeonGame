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
    }
    void FixedUpdate()
    {
        this.Attack(anim, bluewitchdoctor.GetAttackSpeed(), bluewitchdoctor.GetDamage(), bluewitchdoctor.GetCriticalDamage(), bluewitchdoctor.GetCriticalPercentage(),13);
        this.Chase(nav, anim, bluewitchdoctor.GetMoveSpeeed());
        this.HangAround(anim, 25);
    }
}
