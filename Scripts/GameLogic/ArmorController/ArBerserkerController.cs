using Assets.Scripts.Classes.ITEM.ARMOR;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArBerserkerController : MonoBehaviour
{
    BoxCollider Weapon;
    public ArBerserker ReferenceArmor;
    AudioSource audioSource;
    public AudioClip[] clips;
    private void Start()
    {
        ReferenceArmor = new ArBerserker(this.gameObject);
        audioSource = this.GetComponent<AudioSource>();
    }

    //HAMMER-SWORD RUN
    public void OnLeftStepGrounded() { audioSource.PlayOneShot(clips[0]); }
    public void OnRightStepGrounded() { audioSource.PlayOneShot(clips[0]); }


    //HAMMER-SWORD ATTACK
    public void OnAttackBegin()
    {
        audioSource.PlayOneShot(clips[1]);
        Weapon = this.gameObject.GetComponentInChildren<BoxCollider>();
        Weapon.enabled = true;
        if (Weapon.tag == "WeaponSword")
        {
            GameObject CloneSlash = Instantiate(Weapon.gameObject.GetComponent<SwordController>().Slash, Weapon.gameObject.GetComponent<SwordController>().HitPos.position,
              Weapon.gameObject.GetComponent<SwordController>().HitPos.rotation) as GameObject;
            CloneSlash.transform.Rotate(-90, 90, -30);

        }
        if (Weapon.tag == "WeaponHammer")
        {
            GameObject CloneSlash = Instantiate(Weapon.gameObject.GetComponent<HammerController>().Slash, Weapon.gameObject.GetComponent<HammerController>().HitPos.position,
                Weapon.gameObject.GetComponent<HammerController>().HitPos.rotation) as GameObject;
            CloneSlash.transform.position += new Vector3(0, 1, 0);
            CloneSlash.transform.Rotate(-90, 0, -30);
        }
    }
    public void OnAttackMid()
    {
        audioSource.PlayOneShot(clips[2]);
        Weapon = this.gameObject.GetComponentInChildren<BoxCollider>();
        if (Weapon.tag == "WeaponSword")
        {
            GameObject CloneSlash = Instantiate(Weapon.gameObject.GetComponent<SwordController>().Slash, Weapon.gameObject.GetComponent<SwordController>().HitPos.position,
              Weapon.gameObject.GetComponent<SwordController>().HitPos.rotation) as GameObject;
            CloneSlash.transform.Rotate(-90, 90, -30);
        }
        if (Weapon.tag == "WeaponHammer")
        {
            GameObject CloneSlash = Instantiate(Weapon.gameObject.GetComponent<HammerController>().Slash, Weapon.gameObject.GetComponent<HammerController>().HitPos.position,
                 Weapon.gameObject.GetComponent<HammerController>().HitPos.rotation) as GameObject;
            CloneSlash.transform.position += new Vector3(0, 1, 0);
            CloneSlash.transform.Rotate(-90, 0, -30);
        }
    }
    public void OnAttackEnd()
    {
        Weapon = this.gameObject.GetComponentInChildren<BoxCollider>();
        Weapon.enabled = false;
    }

}
