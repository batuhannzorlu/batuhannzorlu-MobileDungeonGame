using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PUCrossController : MonoBehaviour
{
    public PUCross ReferencePowerup;
    void Start() { ReferencePowerup = new PUCross(this.gameObject); }
}
