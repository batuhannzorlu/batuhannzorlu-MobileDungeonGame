using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PUSightController : MonoBehaviour
{
    public PUSight ReferencePowerup;
    void Start() { ReferencePowerup = new PUSight(this.gameObject); }
}
