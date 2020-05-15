using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory:MonoBehaviour
{
    public bool[] isFull;
    public GameObject[] Slots;
    public string Owner;

    private void Start() { Owner = this.gameObject.tag; }

}