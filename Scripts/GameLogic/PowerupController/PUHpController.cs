using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PUHpController : MonoBehaviour
{
    public PUHeart ReferencePowerup;
    public GameObject PowerUpSound;
    void Start() { ReferencePowerup = new PUHeart(this.gameObject); }
    private void OnDestroy() { Instantiate(PowerUpSound, transform.position, transform.rotation); }
}
