using Assets.Scripts.Classes;
using Assets.Scripts.Classes.ITEM.ARMOR;
using Assets.Scripts.Classes.ITEM.WEAPON;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class Berserker : Character
{
    private GameObject Shield;

    public Berserker(string _nick,string _Key)
    {
        this.Nick = _nick;
        this.Location = Vector3.zero;
        Pet DefaultPet = new Pet();
        this.Pet = DefaultPet.GetDefaultPet();
        ArBerserker DefaultArberserker = new ArBerserker();
        Shield DefaultShield = new Shield();
        switch (_Key)
        {
            case "Hammer":
                this.Type = "PlayerBerserkerHammer";
                Hammer DefaultHammer = new Hammer();
                this.Armor = DefaultArberserker.GetDefaultArmor();
                this.Weapon = DefaultHammer.GetDefaultWeapon();
                this.Shield = DefaultShield.GetDefaultArmor();
                this.AttackDamage = DefaultHammer.GetDamage();
                this.Defense = DefaultArberserker.GetDefense();
                 this.AttackSpeed = 1f;
                this.MovementSpeed = 100;
                this.Health = 100;
                break;
            case "Sword":
                this.Type = "PlayerBerserkerSword";
                Sword DefaultSword = new Sword();
                this.Armor = DefaultArberserker.GetDefaultArmor();
                this.Weapon = DefaultSword.GetDefaultWeapon();
                this.Shield = DefaultShield.GetDefaultArmor();
                this.AttackDamage = DefaultSword.GetDamage();
                this.Defense = DefaultArberserker.GetDefense();
                this.AttackSpeed = 1.5f;
                this.MovementSpeed = 110;
                this.Health = 100;
                break;
            default:
                break;
        }
    }

    public GameObject GetShield() { return this.Shield; }
    protected void SetShield(GameObject _Shield) { this.Shield = _Shield; }

    public void Stun() { }
    public void Block() { }
    override public void  Attack()
    {
        this.Rigidbody.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ;    
    }
    






}



