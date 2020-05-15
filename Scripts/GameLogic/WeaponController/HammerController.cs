using Assets.Scripts.Classes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HammerController : MonoBehaviour
{
    public Transform HitPos;
    public GameObject Slash;
    public GameObject Critical;
    public GameObject Fire;
    public Hammer ReferenceWeapon;
    private void Start() { ReferenceWeapon = new Hammer(this.gameObject); }

}
