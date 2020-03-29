using Assets.Scripts.Classes.ITEM.WEAPON;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordController : MonoBehaviour
{
    public Sword ReferenceWeapon;
    private void Start() { ReferenceWeapon = new Sword(this.gameObject); }
}
