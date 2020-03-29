using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PULuckclover : PowerUp
{
    private float BonusLuckclover { get; set; }


    public PULuckclover(GameObject _ReferencePowerup)
    {
        const string PathPowerupObj = "GameAssetInScene/ITEM/POWERUP/_POWERUP/LUCKCLOVER";
        const string PathPowerupImg = "GameAssetInScene/ItemSprite/PowerUpSprite/Luckclover";
        this.LoadAssets(this.GetType(), PathPowerupObj, PathPowerupImg);
        this.IsCaptured = false;
        this.SetPowerUpFeatures(_ReferencePowerup);
    }

    public float GetBonusLuckclover() { return this.BonusLuckclover; }

    public void SetBonusLuckclover(float _BonusLuckclover) { this.BonusLuckclover = _BonusLuckclover; }
    override public void AdjustFeature()
    {
        switch (this.GetLevel())
        {
            case 0:
                this.SetBonusLuckclover(5);
                break;
            case 1:
                this.SetBonusLuckclover(10);
                break;
            default:
                break;
        }
    }
}
