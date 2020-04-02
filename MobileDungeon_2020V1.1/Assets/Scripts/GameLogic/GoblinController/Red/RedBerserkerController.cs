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

        this.gameObject.GetComponent<GoblinHealthManager>().SetHealth(redberserker.GetHealth());
        this.gameObject.GetComponent<GoblinHealthManager>().SetDefense(redberserker.GetDefense());

        this.transform.GetComponentInChildren<GoblinWeaponFeatures>().Damage = redberserker.GetDamage();
        this.transform.GetComponentInChildren<GoblinWeaponFeatures>().CriticalDamage = redberserker.GetCriticalDamage();


    }
    void FixedUpdate()
    {
        if (this.gameObject.GetComponent<GoblinHealthManager>().GetHealth() > 0)
        {
            this.Attack(anim, redberserker.GetAttackSpeed(), redberserker.GetDamage(), redberserker.GetCriticalDamage(), redberserker.GetCriticalPercentage(), 3);
            this.Chase(nav, anim, redberserker.GetMoveSpeeed());
            this.HangAround(anim, 35);
        }
        else
            this.StartCoroutine("Die");
    }
}
