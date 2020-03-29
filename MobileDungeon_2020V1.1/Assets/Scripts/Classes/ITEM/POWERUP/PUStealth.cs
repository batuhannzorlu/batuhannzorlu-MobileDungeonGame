using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PUStealth : PowerUp
{
    private float BonusStealth { get; set; }


    public PUStealth(GameObject _ReferencePowerup)
    {
        const string PathPowerupObj = "GameAssetInScene/ITEM/POWERUP/_POWERUP/STEALTH";
        const string PathPowerupImg = "GameAssetInScene/ItemSprite/PowerUpSprite/Stealth";
        this.LoadAssets(this.GetType(), PathPowerupObj, PathPowerupImg);
        this.IsCaptured = false;
        this.SetPowerUpFeatures(_ReferencePowerup);
    }

    public float GetBonusStealth() { return this.BonusStealth; }

    public void SetBonusStealth(float _BonusStealth) { this.BonusStealth = _BonusStealth; }
    override public void AdjustFeature()
    {
        switch (this.GetLevel())
        {
            case 0:
                this.SetBonusStealth(5);
                break;
            case 1:
                this.SetBonusStealth(10);
                break;
            default:
                break;
        }
    }
}
