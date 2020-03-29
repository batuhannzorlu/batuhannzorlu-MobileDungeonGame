using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PUCross : PowerUp
{
    private float BonusCross { get; set; }

    public PUCross(GameObject _ReferencePowerup)
    {
        const string PathPowerupObj = "GameAssetInScene/ITEM/POWERUP/_POWERUP/CROSS";
        const string PathPowerupImg = "GameAssetInScene/ItemSprite/PowerUpSprite/Cross";
        this.LoadAssets(this.GetType(), PathPowerupObj, PathPowerupImg);
        this.IsCaptured = false;
        this.SetPowerUpFeatures(_ReferencePowerup);
    }

    public float GetBonusCross() { return this.BonusCross; }

    public void SetBonusCross(float _BonusCross) { this.BonusCross = _BonusCross; }

    override public void AdjustFeature()
    {
        switch (this.GetLevel())
        {
            case 0:
                this.SetBonusCross(5);
                break;
            case 1:
                this.SetBonusCross(10);
                break;
            default:
                break;
        }
    }
}
