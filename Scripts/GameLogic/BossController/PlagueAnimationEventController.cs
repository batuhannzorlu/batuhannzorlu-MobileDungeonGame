using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlagueAnimationEventController : MonoBehaviour
{
    BoxCollider Weapon;
    private Animator anim;
    public AudioSource audiosource;
    public AudioClip[] clip;
    /// <summary>
    // ANIMATION EVENTS
    /// </summary>
    public void OnBeginAttack()
    {
        Weapon = this.GetComponentInChildren<BoxCollider>();
        audiosource.PlayOneShot(clip[0]);
        Weapon.enabled = true;
    }
    public void OnEndAttack()
    {
        Weapon = this.GetComponentInChildren<BoxCollider>();
        Weapon.enabled = false;
    }
}
