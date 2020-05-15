using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Classes
{
   public class CrossBow:Character
    {

        public CrossBow(string _nick, GameObject _Armor, GameObject _Weapon, Animator _CharacterAnimations)
        {
            this.Nick = _nick;
            this.Type = "CrossBow";
            this.Armor = _Armor;
            this.AttackSpeed = 0.8f;
            this.AttackDamage = 1.2f;
            this.MovementSpeed = 80;
            this.Weapon = _Weapon;
            this.Health = 100;
            this.Defense = 70;
            this.Location = Vector3.zero;
            this.CharacterAnimations = _CharacterAnimations;
        }

        public void poison() { }

    }
}
