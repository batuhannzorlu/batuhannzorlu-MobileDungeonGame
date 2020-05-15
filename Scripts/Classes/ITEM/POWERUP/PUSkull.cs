using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PUSkull : PowerUp
{
    private float BonusSkull { get; set; }


    public PUSkull(GameObject _ReferencePowerup)
    {
        const string PathPowerupObj = "GameAssetInScene/ITEM/POWERUP/_POWERUP/SKULL";
        const string PathPowerupImg = "GameAssetInScene/ItemSprite/PowerUpSprite/Skull";
        this.LoadAssets(this.GetType(), PathPowerupObj, PathPowerupImg);
        this.IsCaptured = false;
        this.SetPowerUpFeatures(_ReferencePowerup);
    }

    public float GetBonusSkull() { return this.BonusSkull; }

    public void SetBonusSkull(float _BonusSkull) { this.BonusSkull = _BonusSkull; }
    override public void AdjustFeature()
    {
        switch (this.GetLevel())
        {
            case 0:
                this.SetBonusSkull(5);
                break;
            case 1:
                this.SetBonusSkull(10);
                break;
            default:
                break;
        }
    }
}
