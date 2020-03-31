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
    public float GetDefense() { return this.Defense; }

    public void SetHealth(float _Health) { this.Health = _Health; }   
    public void SetDefense(float _Defense) { this.Defense = _Defense; }
    public void SetCurrentHealth(float _Damage)
    {
        if (this.Health - _Damage >= 0)
            this.Health -= _Damage;
        else
            this.Health = 0;
    }

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
                SetCurrentHealth(this.Health-Mathf.Abs(_CloneReferenceHammer.GetDamage() - this.GetDefense()));
                slider.value = this.GetHealth();
                break;
            case "WeaponSword":
                Sword _CloneReferenceSword;
                _CloneReferenceSword = _PlayerWeapon.gameObject.GetComponent<SwordController>().ReferenceWeapon;
                SetCurrentHealth(Mathf.Abs(_CloneReferenceSword.GetDamage() - this.GetDefense()));
                slider.value = this.GetHealth();
                break;
            case "WeaponBow":
                Bow _CloneReferenceBow;
                _CloneReferenceBow = _PlayerWeapon.gameObject.GetComponent<BowController>().ReferenceWeapon;
                SetCurrentHealth(Mathf.Abs(_CloneReferenceBow.GetDamage() - this.GetDefense()));
                slider.value = this.GetHealth();
                break;
        }

    }
}
