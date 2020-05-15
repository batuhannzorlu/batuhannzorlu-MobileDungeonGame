using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MicroOrc : Pet
{
    override protected float ExtraDamage { get; set; }
    override protected float ExtraDefense { get; set; }

    public MicroOrc(GameObject _ReferenceMicroOrc)
    {
        const string PathPetObj = "MİCROORC OBJ PATH";
        const string PathPetImg = "MİCROORC IMG PATH";
        this.SetType("Pet");
        this.LoadAssets(this.GetType(), PathPetObj, PathPetImg);
        this.SetPetFeatures(_ReferenceMicroOrc);
    }

    override protected void AdjustExtraDamage()
    {
        switch (this.GetLevel())
        {
            case 0:
                this.SetExtraDamage(5);
                break;
            case 1:
                this.SetExtraDamage(10);
                break;
            case 2:
                this.SetExtraDamage(15);
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
