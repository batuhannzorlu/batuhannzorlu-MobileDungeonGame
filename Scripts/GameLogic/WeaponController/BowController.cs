using Assets.Scripts.Classes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowController : MonoBehaviour
{
    public Bow ReferenceWeapon;
    private void Start() { ReferenceWeapon = new Bow(this.gameObject); }

}
