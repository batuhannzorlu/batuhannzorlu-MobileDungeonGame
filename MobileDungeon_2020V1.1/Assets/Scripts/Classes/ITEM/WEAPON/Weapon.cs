using Assets.Scripts.Classes.ITEM;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : Item
{
    private float Damage { get; set; }
    protected float CriticalDamage { get; set; }
    protected float CriticalPercentage { get; set; }

    
    public float GetDamage() { return this.Damage; }
    public bool GetIsCaptured() { return this.IsCaptured; }
    public float GetCriticalDamage() { return this.CriticalDamage; }
    public float GetCriticalPercentage() { return this.CriticalPercentage; }

    protected void SetDamage(float _Damage) { this.Damage = _Damage; }
    protected void SetCriticalDamage(float _CriticalDamage) { this.CriticalDamage = _CriticalDamage; }
    protected void SetCriticalPercentage(float _CriticalPercentage) { this.CriticalPercentage = _CriticalPercentage; }
    protected void SetWeaponFeatures(GameObject _ReferenceWeapon)
    {
        Dictionary<Sprite, int> dictionary = new Dictionary<Sprite, int>();
        dictionary = this.FindItemWithObj(_ReferenceWeapon);
        foreach (KeyValuePair<Sprite, int> _Level in dictionary)
        {
            this.SetLevel(_Level.Value);
            this.AdjustDamage();
            this.AdjustCriticalDamage();
            this.AdjustCriticalPercentage();

        }
    }

    virtual public GameObject GetDefaultWeapon() { return null;  }

    virtual protected void AdjustDamage() { }
    virtual protected  void AdjustCriticalDamage() { }
    virtual protected  void AdjustCriticalPercentage() { }






}