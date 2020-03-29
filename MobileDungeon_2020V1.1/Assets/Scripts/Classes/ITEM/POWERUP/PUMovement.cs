using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PUMovement : PowerUp
{
    private float BonusMovement { get; set; }


    public PUMovement(GameObject _ReferencePowerup)
    {
        const string PathPowerupObj = "GameAssetInScene/ITEM/POWERUP/_POWERUP/MOVEMENT";
        const string PathPowerupImg = "GameAssetInScene/ItemSprite/PowerUpSprite/Movement";
        this.LoadAssets(this.GetType(), PathPowerupObj, PathPowerupImg);
        this.IsCaptured = false;
        this.SetPowerUpFeatures(_ReferencePowerup);
    }

    public float GetBonusMovement() { return this.BonusMovement; }

    public void SetBonusMovement(float _BonusMovement) { this.BonusMovement = _BonusMovement; }
    override public void AdjustFeature()
    {
        switch (this.GetLevel())
        {
            case 0:
                this.SetBonusMovement(5);
                break;
            case 1:
                this.SetBonusMovement(10);
                break;
            default:
                break;
        }
    }
}
