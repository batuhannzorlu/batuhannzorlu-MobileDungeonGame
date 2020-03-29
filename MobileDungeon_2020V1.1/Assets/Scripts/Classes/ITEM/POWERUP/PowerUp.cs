using Assets.Scripts.Classes.ITEM;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : Item
{
    protected int RemainTime { get; set; }

    public float GetRemainTime() { return this.RemainTime; }

    public void SetRemainTime(int _RemanTime) { this.RemainTime = _RemanTime; }

    public virtual void AdjustFeature() { }

    public PowerUp()
    {
        this.SetType("PowerUp");
    }


    protected void SetPowerUpFeatures(GameObject _ReferencePowerUp)
    {
        Dictionary<Sprite, int> dictionary = new Dictionary<Sprite, int>();
        dictionary = this.FindItemWithObj(_ReferencePowerUp);
        foreach (KeyValuePair<Sprite, int> _Level in dictionary)
        {
            this.SetLevel(_Level.Value);
            this.AdjustFeature();

        }
    }

}
