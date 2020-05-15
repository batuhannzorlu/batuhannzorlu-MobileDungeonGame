using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PUSkullController : MonoBehaviour
{
    public PUSkull ReferencePowerup;
    void Start() { ReferencePowerup = new PUSkull(this.gameObject); }
}
