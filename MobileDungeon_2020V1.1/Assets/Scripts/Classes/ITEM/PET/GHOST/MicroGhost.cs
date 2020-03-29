using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MicroGhost : Pet
{
    override protected float ExtraCriticalDamage { get; set; }
    override protected float ExtraMoveSpeed { get; set; }

    public MicroGhost(GameObject _ReferenceMicroGhost)
    {
        const string PathPetObj = "MİCROORC OBJ PATH";
        const string PathPetImg = "MİCROORC IMG PATH";
        this.SetType("Pet");
        this.LoadAssets(this.GetType(), PathPetObj, PathPetImg);
        this.SetPetFeatures(_ReferenceMicroGhost);
    }

    override protected void AdjustExtraCriticalDamage()
    {
        switch (this.GetLevel())
        {
            case 0:
                this.SetExtraCriticalDamage(5);
                break;
            case 1:
                this.SetExtraCriticalDamage(10);
                break;
            case 2:
                this.SetExtraCriticalDamage(15);
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
