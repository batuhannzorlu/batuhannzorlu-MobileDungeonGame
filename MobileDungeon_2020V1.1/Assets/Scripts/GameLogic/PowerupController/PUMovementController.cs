using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PUMovementController : MonoBehaviour
{
    public PUMovement ReferencePowerup;
    void Start() { ReferencePowerup = new PUMovement(this.gameObject); }
}
