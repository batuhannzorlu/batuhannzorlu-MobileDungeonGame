using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PUResurrection : PowerUp
{
    private float BonusResurrection { get; set; }


    public PUResurrection(GameObject _ReferencePowerup)
    {
        const string PathPowerupObj = "GameAssetInScene/ITEM/POWERUP/_POWERUP/RESURRECTION";
        const string PathPowerupImg = "GameAssetInScene/ItemSprite/PowerUpSprite/Resurrection"; 
        this.LoadAssets(this.GetType(), PathPowerupObj, PathPowerupImg);
        this.IsCaptured = false;
        this.SetPowerUpFeatures(_ReferencePowerup);
    }

    public float GetBonusResurrection() { return this.BonusResurrection; }
    public void SetBonusResurrection(float _BonusResurrection) { this.BonusResurrection = _BonusResurrection; }
    override public void AdjustFeature()
    {
        switch (this.GetLevel())
        {
            case 0:
                this.SetBonusResurrection(5);
                break;
            case 1:
                this.SetBonusResurrection(10);
                break;
            default:
                break;
        }
    }
}
