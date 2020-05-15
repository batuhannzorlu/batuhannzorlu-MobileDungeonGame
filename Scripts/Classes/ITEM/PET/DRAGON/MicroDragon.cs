using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MicroDragon : Pet
{
    override protected float ExtraDefense { get; set; }
    override protected float ExtraAttackSpeed { get; set; }

    public MicroDragon(GameObject _ReferenceMicroDragon)
    {
        const string PathPetObj = "MİCRODRAGON OBJ PATH";
        const string PathPetImg = "MİCRODRAGON IMG PATH";
        this.SetType("Pet");
        this.LoadAssets(this.GetType(), PathPetObj, PathPetImg);
        this.SetPetFeatures(_ReferenceMicroDragon);
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
    override protected void AdjustExtraDefense()
    {
        switch (this.GetLevel())
        {
            case 0:
                this.SetExtraDefense(5);
                break;
            case 1:
                this.SetExtraDefense(10);
                break;
            case 2:
                this.SetExtraDefense(15);
                break;

            default:
                break;
        }
    }
}
