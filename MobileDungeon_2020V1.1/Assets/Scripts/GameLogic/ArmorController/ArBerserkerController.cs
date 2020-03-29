using Assets.Scripts.Classes.ITEM.ARMOR;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArBerserkerController : MonoBehaviour
{

    public ArBerserker ReferenceArmor;
    private void Start() { ReferenceArmor = new ArBerserker(this.gameObject); }

}
