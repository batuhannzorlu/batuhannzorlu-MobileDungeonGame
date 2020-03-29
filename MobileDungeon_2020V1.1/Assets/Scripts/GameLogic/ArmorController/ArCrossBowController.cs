using Assets.Scripts.Classes.ITEM.ARMOR;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArCrossBowController : MonoBehaviour
{
    public ArCrossBow ReferenceArmor;
    private void Start() { ReferenceArmor = new ArCrossBow(this.gameObject); }

}
