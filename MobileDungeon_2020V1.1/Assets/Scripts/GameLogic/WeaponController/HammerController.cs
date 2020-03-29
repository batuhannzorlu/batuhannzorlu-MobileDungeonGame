using Assets.Scripts.Classes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HammerController : MonoBehaviour
{
    public Hammer ReferenceWeapon;
    private void Start() { ReferenceWeapon = new Hammer(this.gameObject); }

}
