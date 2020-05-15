using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class Character
{
    protected string Type { get; set; }
    protected float AttackDamage { get; set; }
    protected float Defense { get; set; }
    protected Vector3 Location { get; set; }
    protected GameObject Armor { get; set; }
    protected GameObject Weapon { get; set; }
    protected GameObject Pet { get; set; }
    protected string Nick { get; set; }
    protected float Health { get; set; }
    protected Inventory Inventory { get; set; }
    protected float MovementSpeed { get; set; }
    protected float AttackSpeed { get; set; }
    protected Animator CharacterAnimations { get; set; }
    protected Rigidbody Rigidbody { get; set; }



    protected void SetAttackSpeed(float _AtttackSpeed) { this.AttackSpeed = _AtttackSpeed; }
    protected void SetAttackDamage(float _AttackDamage) { this.AttackDamage = _AttackDamage; }
    protected void SetHealth(float _Health) { this.Health = _Health; }
    protected void SetDefense(float _Defense) { this.Defense = _Defense; }
    protected void SetMovementSpeed(float _MovementSpeed) { this.MovementSpeed = _MovementSpeed; }

    virtual protected void SetWeapon(GameObject _Weapon) { this.Weapon = _Weapon; }
    virtual protected void SetArmor(GameObject _Armor) { this.Armor = _Armor; }
    virtual protected void SetPet(GameObject _Pet) { this.Pet = _Pet; }


    public float GetAttackSpeed() { return this.AttackSpeed; }
    public float GetAttackDamage() { return this.AttackDamage; }
    public float GetHealth() { return this.Health; }
    public float GetDefense() { return this.Defense; }
    public float GetMovementSpeed() { return this.MovementSpeed; }
    public string GetNick() { return this.Nick; }

    virtual public GameObject GetWeapon() { return this.Weapon; }
    virtual public GameObject GetPet() { return this.Pet; }
    virtual public GameObject GetArmor() { return this.Armor; }


    virtual public void Attack() { }
    virtual public void Move() { }
    virtual public void GetItem() { }

}



