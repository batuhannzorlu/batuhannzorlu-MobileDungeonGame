
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MicroZombie : Pet
{
    override protected float ExtraAttackSpeed { get; set; }
    override protected float ExtraMoveSpeed { get; set; }

    public MicroZombie(GameObject _ReferenceMicroZombie)
    {
        const string PathPetObj = "MİCRODRAGON OBJ PATH";
        const string PathPetImg = "MİCRODRAGON IMG PATH";
        this.SetType("Pet");
        this.LoadAssets(this.GetType(), PathPetObj, PathPetImg);
        this.SetPetFeatures(_ReferenceMicroZombie);
    }

    override protected void AdjustExtraAttackSpeed()
    {
        switch (this.GetLevel())
        {
            case 0:
                this.SetExtraAttackSpeed(5);
                break;
            case 1:
                this.SetExtraAttackSpeed(10);
                break;
            case 2:
                this.SetExtraAttackSpeed(15);
                break;

            default:
                break;
        }
    }
    override protected void AdjustExtraMoveSpeed()
    {
        switch (this.GetLevel())
        {
            case 0:
                this.SetExtraMoveSpeed(5);
                break;
            case 1:
                this.SetExtraMoveSpeed(10);
                break;
            case 2:
                this.SetExtraMoveSpeed(15);
                break;
            default:
                break;
        }
    }
}
