
using Assets.Scripts.Classes.ITEM;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Armor : Item
{
    private float Defense { get; set; }

    public float GetDefense() { return Defense; }

    protected void SetDefense(float _Defense) { this.Defense = _Defense; }

    virtual protected void AdjustDefense() { }

    virtual public GameObject GetDefaultArmor() { return null; }

    public Dictionary<GameObject, int> GetArmorWImg(Sprite _ItemImg) { return FindItemWithImg(_ItemImg); }

    protected void SetArmorFeatures(GameObject ReferenceArmor)
    {
        Dictionary<Sprite, int> dictionary = new Dictionary<Sprite, int>();
        dictionary = this.FindItemWithObj(ReferenceArmor);
        foreach (KeyValuePair<Sprite, int> ele1 in dictionary)
        {            
            SetLevel(ele1.Value);
            AdjustDefense();
        }
    }

    protected void SetArmorFeaturesWImg(Sprite ReferenceArmor)
    {
        Dictionary<GameObject, int> dictionary = new Dictionary<GameObject, int>();
        dictionary = this.FindItemWithImg(ReferenceArmor);
        foreach (KeyValuePair<GameObject, int> ele1 in dictionary)
        {
            SetLevel(ele1.Value);
            AdjustDefense();
        }
    }
}




