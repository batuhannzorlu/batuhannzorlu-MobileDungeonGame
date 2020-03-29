using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PUHpController : MonoBehaviour
{
    public PUHeart ReferencePowerup;
    void Start() { ReferencePowerup = new PUHeart(this.gameObject); }
}
