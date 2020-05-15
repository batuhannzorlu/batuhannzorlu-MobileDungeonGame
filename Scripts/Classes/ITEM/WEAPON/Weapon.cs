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
    public Dictionary<GameObject, int> GetWeaponWImg(Sprite _ItemImg) { return FindItemWithImg(_ItemImg); }
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
    protected void SetWeaponFeaturesWImg(Sprite _ReferenceWeapon)
    {
        Dictionary<GameObject, int> dictionary = new Dictionary<GameObject, int>();
        dictionary = this.FindItemWithImg(_ReferenceWeapon);
        foreach (KeyValuePair<GameObject, int> ele1 in dictionary)
        {
            SetLevel(ele1.Value);          
        }
    }

    virtual public GameObject GetDefaultWeapon() { return null;  }

    virtual protected void AdjustDamage() { }
    virtual protected  void AdjustCriticalDamage() { }
    virtual protected  void AdjustCriticalPercentage() { }






}