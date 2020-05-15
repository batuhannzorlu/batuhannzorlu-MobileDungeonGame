using Assets.Scripts.Classes.ITEM.WEAPON;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class SwordController : MonoBehaviour
{
    public Transform HitPos;
    public GameObject Slash;
    public GameObject Critical;
    public GameObject Fire;
    public Sword ReferenceWeapon;

    public bool IsHitEnemy = false;

    private void Start()
    {
        ReferenceWeapon = new Sword(this.gameObject);
    }
    private void OnTriggerEnter(Collider Goblin)
    {
        if (Goblin.tag.StartsWith("Enemy"))
            IsHitEnemy = true;         
    }  
}
