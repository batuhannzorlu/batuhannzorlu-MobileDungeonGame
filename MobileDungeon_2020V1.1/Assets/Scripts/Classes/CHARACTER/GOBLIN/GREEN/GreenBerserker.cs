using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenBerserker : GreenGoblin
{
    const string PathGoblinObj = "GameAssetInScene/ITEM/ENEMY/BERSERKER/GREEN";
    public GreenBerserker(GameObject _ReferenceGreenBerserker)
    {
        this.SetType("GreenBerserker");
        this.LoadAssets(this.GetType(), PathGoblinObj);
        this.SetGoblinFeatures(_ReferenceGreenBerserker);
        this.UnLoadAssets();
    }

    protected override void AdjustDamage()
    {
        switch (this.GetLevel())
        {
            case 0:
                this.SetDamage(this.GetDamage() + 10);
                break;
            case 1:
                this.SetDamage(this.GetDamage() + 15);
                break;
            case 2:
                this.SetDamage(this.GetDamage() + 20);
                break;
            case 3:
                this.SetDamage(this.GetDamage() + 25);
                break;
            case 4:
                this.SetDamage(this.GetDamage() + 30);
                break;
            case 5:
                this.SetDamage(this.GetDamage() + 35);
                break;
            default:
                break;
        }
        base.AdjustDamage();
    }
    protected override void AdjustHealth()
    {
        switch (this.GetLevel())
        {
            case 0:
                this.SetHealth(this.GetHealth() + 10);
                break;
            case 1:
                this.SetHealth(this.GetHealth() + 15);
                break;
            case 2:
                this.SetHealth(this.GetHealth() + 20);
                break;
            case 3:
                this.SetHealth(this.GetHealth() + 25);
                break;
            case 4:
                this.SetHealth(this.GetHealth() + 30);
                break;
            case 5:
                this.SetHealth(this.GetHealth() + 35);
                break;
            default:
                break;
        }
        base.AdjustHealth();
    }
    protected override void AdjustDefense()
    {
        switch (this.GetLevel())
        {
            case 0:
                this.SetHealth(this.GetHealth() + 10);
                break;
            case 1:
                this.SetHealth(this.GetHealth() + 15);
                break;
            case 2:
                this.SetHealth(this.GetHealth() + 20);
                break;
            case 3:
                this.SetHealth(this.GetHealth() + 25);
                break;
            case 4:
                this.SetHealth(this.GetHealth() + 30);
                break;
            case 5:
                this.SetHealth(this.GetHealth() + 35);
                break;
            default:
                break;
        }
        base.AdjustDefense();
    }
    protected override void AdjustAttackSpeed()
    {
        switch (this.GetLevel())
        {
            case 0:
                this.SetAttackSpeed(this.GetAttackSpeed() + 10);
                break;
            case 1:
                this.SetAttackSpeed(this.GetAttackSpeed() + 15);
                break;
            case 2:
                this.SetAttackSpeed(this.GetAttackSpeed() + 20);
                break;
            case 3:
                this.SetAttackSpeed(this.GetAttackSpeed() + 25);
                break;
            case 4:
                this.SetAttackSpeed(this.GetAttackSpeed() + 30);
                break;
            case 5:
                this.SetAttackSpeed(this.GetAttackSpeed() + 35);
                break;
            default:
                break;
        }
        base.AdjustAttackSpeed();
    }
    protected override void AdjustCriticalDamage()
    {
        switch (this.GetLevel())
        {
            case 0:
                this.SetCriticalDamage(this.GetCriticalDamage() + 10);
                break;
            case 1:
                this.SetCriticalDamage(this.GetCriticalDamage() + 15);
                break;
            case 2:
                this.SetCriticalDamage(this.GetCriticalDamage() + 20);
                break;
            case 3:
                this.SetCriticalDamage(this.GetCriticalDamage() + 25);
                break;
            case 4:
                this.SetCriticalDamage(this.GetCriticalDamage() + 30);
                break;
            case 5:
                this.SetCriticalDamage(this.GetCriticalDamage() + 35);
                break;
            default:
                break;
        }
        base.AdjustCriticalDamage();
    }
    protected override void AdjustVisionDistance()
    {
        switch (this.GetLevel())
        {
            case 0:
                this.SetVisionDistance(this.GetVisionDistance() + 10);
                break;
            case 1:
                this.SetHealth(this.GetVisionDistance() + 15);
                break;
            case 2:
                this.SetHealth(this.GetVisionDistance() + 20);
                break;
            case 3:
                this.SetHealth(this.GetVisionDistance() + 25);
                break;
            case 4:
                this.SetHealth(this.GetVisionDistance() + 30);
                break;
            case 5:
                this.SetHealth(this.GetVisionDistance() + 35);
                break;
            default:
                break;
        }
        base.AdjustVisionDistance();
    }
    protected override void AdjustCriticalPercentage()
    {
        switch (this.GetLevel())
        {
            case 0:
                this.SetCriticalPercentage(this.GetCriticalPercentage() + 10);
                break;
            case 1:
                this.SetCriticalPercentage(this.GetCriticalPercentage() + 15);
                break;
            case 2:
                this.SetCriticalPercentage(this.GetCriticalPercentage() + 20);
                break;
            case 3:
                this.SetCriticalPercentage(this.GetCriticalPercentage() + 25);
                break;
            case 4:
                this.SetCriticalPercentage(this.GetCriticalPercentage() + 30);
                break;
            case 5:
                this.SetCriticalPercentage(this.GetCriticalPercentage() + 35);
                break;
            default:
                break;
        }
        base.AdjustCriticalPercentage();
    }
    protected override void AdjustMoveSpeed()
    {
        switch (this.GetLevel())
        {
            case 0:
                this.SetMoveSpeeed(this.GetMoveSpeeed() + 10);
                break;
            case 1:
                this.SetMoveSpeeed(this.GetMoveSpeeed() + 15);
                break;
            case 2:
                this.SetMoveSpeeed(this.GetMoveSpeeed() + 20);
                break;
            case 3:
                this.SetMoveSpeeed(this.GetMoveSpeeed() + 25);
                break;
            case 4:
                this.SetMoveSpeeed(this.GetMoveSpeeed() + 30);
                break;
            case 5:
                this.SetMoveSpeeed(this.GetMoveSpeeed() + 35);
                break;
            default:
                break;
        }
        base.AdjustMoveSpeed();
    }
}
