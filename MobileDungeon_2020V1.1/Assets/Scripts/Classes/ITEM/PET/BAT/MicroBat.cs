using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MicroBat : Pet
{
    override protected float ExtraCriticalPercentage { get; set; }
    override protected float ExtraDefense { get; set; }

    public MicroBat(GameObject _ReferenceMicroBat)
    {
        const string PathPetObj = "MİCROBATH OBJ PATH";
        const string PathPetImg = "MİCROBATH IMG PATH";
        this.SetType("Pet");
        this.LoadAssets(this.GetType(), PathPetObj, PathPetImg);
        this.SetPetFeatures(_ReferenceMicroBat);
    }

    override protected void AdjustExtraCriticalPercentage()
    {
        switch (this.GetLevel())
        {
            case 0:
                this.SetExtraCriticalPercentage(5);
                break;
            case 1:
                this.SetExtraCriticalPercentage(10);
                break;
            case 2:
                this.SetExtraCriticalPercentage(15);
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
