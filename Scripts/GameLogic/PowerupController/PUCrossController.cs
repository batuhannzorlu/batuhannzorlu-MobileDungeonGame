using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PUCrossController : MonoBehaviour
{
    public PUCross ReferencePowerup;
    public GameObject PowerUpSound;
    void Start() { ReferencePowerup = new PUCross(this.gameObject); }
    private void OnDestroy() { Instantiate(PowerUpSound, transform.position, transform.rotation); }

}
