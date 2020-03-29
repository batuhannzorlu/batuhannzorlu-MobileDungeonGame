using Assets.Scripts.Classes.ITEM;
using System.Collections.Generic;
using UnityEngine;

public class Pet : Item
{

    //Percentage
    protected virtual float ExtraDamage { get; set; }
    protected virtual float ExtraCriticalDamage { get; set; }
    protected virtual float ExtraCriticalPercentage { get; set; }
    protected virtual float ExtraDefense { get; set; }
    protected virtual float ExtraMoveSpeed { get; set; }
    protected virtual float ExtraAttackSpeed { get; set; }

    protected float ExtraHp { get; set; }

    public float GetExtraDamage() { return this.ExtraDamage; }
    public float GetExtraCriticalDamage() { return this.ExtraCriticalDamage; }
    public float GetExtraCriticalPercentage() { return this.ExtraCriticalPercentage; }
    public float GetExtraDefense() { return this.ExtraDefense; }
    public float GetExtraHp() { return this.ExtraHp; }
    public float GetExtraMoveSpeed() { return this.ExtraMoveSpeed; }
    public float GetExtraAttackSpeed() { return this.ExtraAttackSpeed; }
    public GameObject GetDefaultPet() { return (GameObject)(Resources.Load("GameAssetInScene/ITEM/PET/DEFAULT/micro_skeleton_sleeping"));}
    
    //DEFAULT PET
    public Pet()
    {
        this.SetType("Pet");
        this.ExtraDamage = 1;
        this.ExtraDefense = 1;
        this.ExtraMoveSpeed = 1;
    }



    protected void SetExtraDamage(float _ExtraDamage) { this.ExtraDamage = _ExtraDamage; }
    protected void SetExtraCriticalDamage(float _ExtraCriticalDamage) { this.ExtraCriticalDamage = _ExtraCriticalDamage; }
    protected void SetExtraCriticalPercentage(float _ExtraCriticalPercentage) { this.ExtraCriticalPercentage = _ExtraCriticalPercentage; }
    protected void SetExtraDefense(float _ExtraDefense) { this.ExtraDefense = _ExtraDefense; }
    protected void SetExtraHp(float _ExtraHp) { this.ExtraHp = _ExtraHp; }
    protected void SetExtraMoveSpeed(float _ExtraMoveSpeed) { this.ExtraMoveSpeed = _ExtraMoveSpeed; }
    protected void SetExtraAttackSpeed(float _ExtraAttackSpeed) { this.ExtraAttackSpeed = _ExtraAttackSpeed; }

    protected virtual void AdjustExtraDamage() { }
    protected virtual void AdjustExtraCriticalDamage() { }
    protected virtual void AdjustExtraCriticalPercentage() { }
    protected virtual void AdjustExtraDefense() { }
    protected virtual void AdjustExtraMoveSpeed() { }
    protected virtual void AdjustExtraAttackSpeed() { }

    private void AdjustExtraHp()
    {
        switch (this.GetLevel())
        {
            case 0:
                this.SetExtraHp(5);
                break;
            case 1:
                this.SetExtraHp(10);
                break;
            case 2:
                this.SetExtraHp(15);
                break;
            default:
                break;
        }
    }

    protected void SetPetFeatures(GameObject _ReferencePet)
    {
        Dictionary<Sprite, int> dictionary = new Dictionary<Sprite, int>();
        dictionary = this.FindItemWithObj(_ReferencePet);
        foreach (KeyValuePair<Sprite, int> _Level in dictionary)
        {
            this.SetLevel(_Level.Value);
            this.AdjustExtraDamage();
            this.AdjustExtraCriticalDamage();
            this.AdjustExtraCriticalPercentage();
            this.AdjustExtraDefense();
            this.AdjustExtraMoveSpeed();
            this.AdjustExtraAttackSpeed();
            this.AdjustExtraHp();
        }
    }
}