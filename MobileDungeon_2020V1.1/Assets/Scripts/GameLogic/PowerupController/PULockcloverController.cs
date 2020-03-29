using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PULockcloverController : MonoBehaviour
{
    public PULuckclover ReferencePowerup;
    void Start() { ReferencePowerup = new PULuckclover(this.gameObject); }
}
