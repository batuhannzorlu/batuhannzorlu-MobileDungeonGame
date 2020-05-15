using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PUMagic : PowerUp
{
    private float BonusMagic { get; set; }


    public PUMagic(GameObject _ReferencePowerup)
    {
        const string PathPowerupObj = "GameAssetInScene/ITEM/POWERUP/_POWERUP/MAGIC";
        const string PathPowerupImg = "GameAssetInScene/ItemSprite/PowerUpSprite/Magic";
        this.LoadAssets(this.GetType(), PathPowerupObj, PathPowerupImg);
        this.IsCaptured = false;
        this.SetPowerUpFeatures(_ReferencePowerup);
    }

    public float GetBonusMagic() { return this.BonusMagic; }

    public void SetBonusMagic(float _BonusMagic) { this.BonusMagic = _BonusMagic; }
    override public void AdjustFeature()
    {
        switch (this.GetLevel())
        {
            case 0:
                this.SetBonusMagic(5);
                break;
            case 1:
                this.SetBonusMagic(10);
                break;
            default:
                break;
        }
    }
}
