using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PUHeart : PowerUp
{
    private float BonusHeart { get; set; }


    public PUHeart(GameObject _ReferencePowerup)
    {
        const string PathPowerupObj = "GameAssetInScene/ITEM/POWERUP/_POWERUP/HP";
        const string PathPowerupImg = "GameAssetInScene/ItemSprite/PowerUpSprite/Heart";
        this.LoadAssets(this.GetType(), PathPowerupObj, PathPowerupImg);
        this.IsCaptured = false;
        this.SetPowerUpFeatures(_ReferencePowerup);
    }

    public float GetBonusHeart() { return this.BonusHeart; }

    public void SetBonusHeart(float _BonusHeart) { this.BonusHeart = _BonusHeart; }
    override public void AdjustFeature()
    {
        switch (this.GetLevel())
        {
            case 0:
                this.SetBonusHeart(5);
                break;
            case 1:
                this.SetBonusHeart(10);
                break;
            default:
                break;
        }
    }
}
