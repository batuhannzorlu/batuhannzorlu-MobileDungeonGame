using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PUSight : PowerUp
{
    private float BonusSight { get; set; }


    public PUSight(GameObject _ReferencePowerup)
    {
        const string PathPowerupObj = "GameAssetInScene/ITEM/POWERUP/_POWERUP/SIGHT";
        const string PathPowerupImg = "GameAssetInScene/ItemSprite/PowerUpSprite/Sight";
        this.LoadAssets(this.GetType(), PathPowerupObj, PathPowerupImg);
        this.IsCaptured = false;
        this.SetPowerUpFeatures(_ReferencePowerup);
    }

    public float GetBonusSight() { return this.BonusSight; }

    public void SetBonusSight(float _BonusSight) { this.BonusSight = _BonusSight; }
    override public void AdjustFeature()
    {
        switch (this.GetLevel())
        {
            case 0:
                this.SetBonusSight(5);
                break;
            case 1:
                this.SetBonusSight(10);
                break;
            default:
                break;
        }
    }
}
