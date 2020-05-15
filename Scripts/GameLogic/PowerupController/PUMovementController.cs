using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PUMovementController : MonoBehaviour
{
    public PUMovement ReferencePowerup;
    public GameObject PowerUpSound;
    void Start() { ReferencePowerup = new PUMovement(this.gameObject); }
    private void OnDestroy() { Instantiate(PowerUpSound, transform.position, transform.rotation); }
}
