using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PUResurrectionController : MonoBehaviour
{
    public PUResurrection ReferencePowerup;
    void Start() { ReferencePowerup = new PUResurrection(this.gameObject); }
}
