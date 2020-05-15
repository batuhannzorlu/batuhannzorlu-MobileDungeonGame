using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PUMagicController : MonoBehaviour
{
    public PUMagic ReferencePowerup;
    public GameObject PowerUpSound;
    void Start() { ReferencePowerup = new PUMagic(this.gameObject); }
    private void OnDestroy() { Instantiate(PowerUpSound, transform.position, transform.rotation); }
}
