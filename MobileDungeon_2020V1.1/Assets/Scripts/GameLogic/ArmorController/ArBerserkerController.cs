using Assets.Scripts.Classes.ITEM.ARMOR;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArBerserkerController : MonoBehaviour
{
    BoxCollider Weapon;
    public ArBerserker ReferenceArmor;

    private void Start() { ReferenceArmor = new ArBerserker(this.gameObject); }

    //HAMMER-SWORD ATTACK
    public void OnAttackBegin()
    {      
        Weapon = this.gameObject.GetComponentInChildren<BoxCollider>();
        Weapon.enabled = true;
    }
    public void OnAttackEnd()
    {
        Weapon = this.gameObject.GetComponentInChildren<BoxCollider>();
        Weapon.enabled = false;
    }

}
