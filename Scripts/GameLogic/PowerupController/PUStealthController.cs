using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PUStealthController : MonoBehaviour
{
    public PUStealth ReferencePowerup;
    void Start() { ReferencePowerup = new PUStealth(this.gameObject); }
}
