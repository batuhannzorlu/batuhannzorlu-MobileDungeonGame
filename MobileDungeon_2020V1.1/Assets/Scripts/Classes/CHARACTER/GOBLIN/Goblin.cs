using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goblin
{
    private string Type { get; set; }
    private int Level { get; set; }
    private float Health { get; set; }
    private float Defense { get; set; }
    private float Damage { get; set; }
    private float AttackSpeed { get; set; }
    private float MoveSpeeed { get; set; }
    private float VisionDistance { get; set; }
    private float CriticalDamage { get; set; }
    private float CriticalPercentage { get; set; }
    private GameObject[] ItemObj { get; set; } = null;

    public Goblin()
    {

    }
    public new string GetType() { return this.Type; }
    public int GetLevel() { return this.Level; }
    public float GetHealth() { return this.Health; }
    public float GetDefense() { return this.Defense; }
    public float GetDamage() { return this.Damage; }
    public float GetAttackSpeed() { return this.AttackSpeed; }
    public float GetMoveSpeeed() { return this.MoveSpeeed; }
    public float GetVisionDistance() { return this.VisionDistance; }
    public float GetCriticalDamage() { return this.CriticalDamage; }
    public float GetCriticalPercentage() { return this.CriticalPercentage; }

    protected void SetType(string _Type) { this.Type = _Type; }
    protected void SetLevel(int _Level) { this.Level = _Level; }
    protected void SetHealth(float _Health) { this.Health = _Health; }
    protected void SetDefense(float _Defense) { this.Defense = _Defense; }
    protected void SetDamage(float _Damage) { this.Damage = _Damage; }
    protected void SetAttackSpeed(float _AttackSpeed) { this.AttackSpeed = _AttackSpeed; }
    protected void SetMoveSpeeed(float _MoveSpeed) { this.MoveSpeeed = _MoveSpeed; }
    protected void SetVisionDistance(float _VisionDistance) { this.VisionDistance = _VisionDistance; }
    protected void SetCriticalDamage(float _CriticalDamage) { this.CriticalDamage = _CriticalDamage; }
    protected void SetCriticalPercentage(float _CriticalPercentage) { this.CriticalPercentage = _CriticalPercentage; }
    protected void SetGoblinFeatures(GameObject _ReferenceGoblin)
    {
        for (int i = 0; i < ItemObj.Length; i++)
        {
            if (ItemObj[i].name == _ReferenceGoblin.name)
            {
                this.SetLevel(i);
                AdjustHealth();
                AdjustDefense();
                AdjustDamage();
                AdjustAttackSpeed();
                AdjustMoveSpeed();
                AdjustVisionDistance();
                AdjustCriticalDamage();
                AdjustCriticalPercentage();
            }

        }
    }

    protected void LoadAssets(string _type, string _FilePathObj)
    {
        if (_type == "RedBerserker" || _type == "RedWitchdoctor" || _type == "GreenWarrior" || _type == "GreenBerserker" 
            || _type == "GreenWitchdoctor" || _type == "RedWarrior" || _type == "BlueBerserker" || _type == "BlueWitchdoctor" || _type == "BlueWarrior")
        {
            this.ItemObj = Resources.LoadAll<GameObject>(_FilePathObj);
            Debug.Log("Loaded Successfully!");
        }
    }
    protected void UnLoadAssets() { Resources.UnloadUnusedAssets(); }

    virtual protected void AdjustHealth() { }
    virtual protected void AdjustDefense() { }
    virtual protected void AdjustDamage() { }
    virtual protected void AdjustAttackSpeed() { }
    virtual protected void AdjustMoveSpeed() { }
    virtual protected void AdjustVisionDistance() { }
    virtual protected void AdjustCriticalDamage() { }
    virtual protected void AdjustCriticalPercentage() { }





}
