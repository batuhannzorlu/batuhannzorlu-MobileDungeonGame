using Assets.Scripts.Classes;
using Assets.Scripts.Classes.ITEM.WEAPON;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoblinHealthManager : MonoBehaviour
{

    public Slider SliderPrefab;
    public Slider slider;
    public Transform SliderPos;
    private float Health { get; set; }
    private float Defense { get; set; }

    public float GetHealth() { return this.Health; }
    public void SetHealth(float _Damage)
    {
        if (this.Health - _Damage >= 0)
            this.Health -= _Damage;
        else
            this.Health = 0;
    }
    public float GetDefense() { return this.Defense; }
    public void SetDefense(float _Defense) { this.Defense = _Defense; }

    void Start()
    {
        GameObject canvas = GameObject.FindWithTag("MainCanvas");
        slider = Instantiate(SliderPrefab, Vector3.zero, Quaternion.identity) as Slider;
        slider.transform.SetParent(canvas.transform);
        slider.transform.localScale = new Vector3(1, 1, 1);
    }
    void Update()
    {
        Vector3 _SliderPos = Camera.main.WorldToScreenPoint(SliderPos.position);
        slider.transform.position = _SliderPos;
    }

    private void OnTriggerEnter(Collider _PlayerWeapon)
    {
        switch (_PlayerWeapon.tag)
        {
            case "WeaponHammer":
                Hammer _CloneReferenceHammer;
                _CloneReferenceHammer = _PlayerWeapon.gameObject.GetComponent<HammerController>().ReferenceWeapon;
                SetHealth(_CloneReferenceHammer.GetDamage() - this.GetDefense());
                break;
            case "WeaponSword":
                Sword _CloneReferenceSword;
                _CloneReferenceSword = _PlayerWeapon.gameObject.GetComponent<SwordController>().ReferenceWeapon;
                SetHealth(_CloneReferenceSword.GetDamage() - this.GetDefense());
                break;
            case "WeaponBow":
                Bow _CloneReferenceBow;
                _CloneReferenceBow = _PlayerWeapon.gameObject.GetComponent<BowController>().ReferenceWeapon;
                SetHealth(_CloneReferenceBow.GetDamage() - this.GetDefense());
                break;
        }

    }
}
