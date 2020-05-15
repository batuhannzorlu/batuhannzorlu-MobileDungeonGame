using Assets.Scripts.Classes.ITEM.ARMOR;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldController : MonoBehaviour
{
    public Shield ReferenceShield;
    private void Start() { ReferenceShield = new Shield(this.gameObject); }
}
