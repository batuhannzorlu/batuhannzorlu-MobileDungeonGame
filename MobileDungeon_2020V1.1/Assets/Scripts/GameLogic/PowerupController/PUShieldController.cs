using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PUShieldController : MonoBehaviour
{
    public PUShield ReferencePowerup;
    void Start() { ReferencePowerup = new PUShield(this.gameObject); }
}
