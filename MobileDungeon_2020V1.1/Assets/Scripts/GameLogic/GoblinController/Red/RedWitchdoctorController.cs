﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RedWitchdoctorController : GoblinMovementManager
{
    NavMeshAgent nav;
    Animator anim;
    RedWitchdoctor redwitchdoctor;

    void Start()
    {
        redwitchdoctor = new RedWitchdoctor(this.gameObject);
        nav = this.gameObject.GetComponent<NavMeshAgent>();
        anim = this.gameObject.GetComponent<Animator>();

       // redwitchdoctor.GetVisionDistance();
    }
    void FixedUpdate()
    {
        this.Attack(anim, redwitchdoctor.GetAttackSpeed(), redwitchdoctor.GetDamage(), redwitchdoctor.GetCriticalDamage(), redwitchdoctor.GetCriticalPercentage(),13);
        this.Chase(nav, anim, redwitchdoctor.GetMoveSpeeed());
        this.HangAround(anim,35);
    }
}