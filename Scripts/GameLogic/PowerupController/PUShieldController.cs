using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PUShieldController : MonoBehaviour
{
    public PUShield ReferencePowerup;
    public GameObject PowerUpSound;
    void Start() { ReferencePowerup = new PUShield(this.gameObject); }
    private void OnDestroy() { Instantiate(PowerUpSound, transform.position, transform.rotation); }
}
