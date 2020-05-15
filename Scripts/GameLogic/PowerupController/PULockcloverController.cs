using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PULockcloverController : MonoBehaviour
{
    public PULuckclover ReferencePowerup;
    public GameObject PowerUpSound;
    void Start() { ReferencePowerup = new PULuckclover(this.gameObject); }
    private void OnDestroy() { Instantiate(PowerUpSound, transform.position, transform.rotation); }
}
