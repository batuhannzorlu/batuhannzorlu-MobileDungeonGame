using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PUShield : PowerUp
{
    private float BonusShield { get; set; }


    public PUShield(GameObject _ReferencePowerup)
    {
        const string PathPowerupObj = "GameAssetInScene/ITEM/POWERUP/_POWERUP/SHIELD";
        const string PathPowerupImg = "GameAssetInScene/ItemSprite/PowerUpSprite/Shield";
        this.LoadAssets(this.GetType(), PathPowerupObj, PathPowerupImg);
        this.IsCaptured = false;
        this.SetPowerUpFeatures(_ReferencePowerup);
    }

    public float GetBonusShield() { return this.BonusShield; }

    public void SetBonusShield(float _BonusShield) { this.BonusShield = _BonusShield; }
    override public void AdjustFeature()
    {
        switch (this.GetLevel())
        {
            case 0:
                this.SetBonusShield(5);
                break;
            case 1:
                this.SetBonusShield(10);
                break;
            default:
                break;
        }
    }
}
