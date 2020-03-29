using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PUMagicController : MonoBehaviour
{
    public PUMagic ReferencePowerup;
    void Start() { ReferencePowerup = new PUMagic(this.gameObject); }
}
