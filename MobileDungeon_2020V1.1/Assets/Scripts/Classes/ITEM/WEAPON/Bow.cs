using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Classes
{
   public class Bow:Weapon
    {
        private float PoisonAmount { get; set; }
        private float PoisonPercentage { get; set; }
        const string PathArmorImg = "GameAssetInScene/ItemSprite/Bows";

        public Bow(GameObject _ReferenceBow)
        {
            const string PathArmorObj = "GameAssetInScene/ITEM/WEAPON/BOW/ONDROP";
            
            this.SetType("Bow");
            this.LoadAssets(this.GetType(),PathArmorObj,PathArmorImg);
            this.IsCaptured = false;
            SetWeaponFeatures(_ReferenceBow);
            this.UnLoadAssets();
        }
        public Bow()
        {
            const string PathArmorObj = "GameAssetInScene/ITEM/WEAPON/BOW/ONPLAYER";
            this.SetType("Bow");
            this.LoadAssets(this.GetType(), PathArmorObj, PathArmorImg);
            this.IsCaptured = true;
            this.SetWeaponFeatures(this.GetDefaultWeapon());
            this.UnLoadAssets();
        }

        public float GetPoisonAmount() { return PoisonAmount; }
        public float GetPoisonPercentage() { return PoisonPercentage; }
        override public GameObject GetDefaultWeapon()
        {

            return (GameObject)(Resources.Load("GameAssetInScene/ITEM/WEAPON/BOW/ONPLAYER/weapon_crossbow_bronze_1 Variant"));
        }

        private void SetPoisonPercentage(float _Level) {

            switch (_Level)
            {
                case 1:
                    this.PoisonAmount = 0.08f;
                    break;
                case 2:
                    this.PoisonAmount = 0.12f;
                    break;
                case 3:
                    this.PoisonAmount = 0.13f;
                    break;
                case 4:
                    this.PoisonAmount = 0.13f;
                    break;
                case 5:
                    this.PoisonAmount = 0.15f;
                    break;
                case 6:
                    this.PoisonAmount = 0.16f;
                    break;
                case 7:
                    this.PoisonAmount = 0.17f;
                    break;
                case 8:
                    this.PoisonAmount = 0.18f;
                    break;
                case 9:
                    this.PoisonAmount = 0.18f;
                    break;
                case 10:
                    this.PoisonAmount = 0.19f;
                    break;
                case 11:
                    this.PoisonAmount = 0.2f;
                    break;
                case 12:
                    this.PoisonAmount = 0.21f;
                    break;
                case 13:
                    this.PoisonAmount = 0.22f;
                    break;
                case 14:
                    this.PoisonAmount = 0.23f;
                    break;
                case 15:
                    this.PoisonAmount = 0.24f;
                    break;
                default:
                    break;
            }

        }
        private void SetPoisonAmount(float _Level) {

            switch (_Level)
            {
                case 1:
                    this.PoisonAmount = 1;
                    break;
                case 2:
                    this.PoisonAmount = 2;
                    break;
                case 3:
                    this.PoisonAmount = 3;
                    break;
                case 4:
                    this.PoisonAmount = 5;
                    break;
                case 5:
                    this.PoisonAmount = 6;
                    break;
                case 6:
                    this.PoisonAmount = 7;
                    break;
                case 7:
                    this.PoisonAmount = 8;
                    break;
                case 8:
                    this.PoisonAmount = 9;
                    break;
                case 9:
                    this.PoisonAmount = 10;
                    break;
                case 10:
                    this.PoisonAmount = 11;
                    break;
                case 11:
                    this.PoisonAmount = 13;
                    break;
                case 12:
                    this.PoisonAmount = 13;
                    break;
                case 13:
                    this.PoisonAmount = 13;
                    break;
                case 14:
                    this.PoisonAmount = 15;
                    break;
                case 15:
                    this.PoisonAmount = 16;
                    break;
                default:
                    break;
            }
            
        }

        override protected void AdjustDamage()
        {
            switch (this.GetLevel())
            {
                case 0:
                    this.SetDamage(0);
                    break;
                case 1:
                    this.SetDamage(1);
                    break;
                case 2:
                    this.SetDamage(2);
                    break;
                case 3:
                    this.SetDamage(3);
                    break;
                case 4:
                    this.SetDamage(4);
                    break;
                case 5:
                    this.SetDamage(5);
                    break;
                case 6:
                    this.SetDamage(6);
                    break;
                case 7:
                    this.SetDamage(7);
                    break;
                case 8:
                    this.SetDamage(8);
                    break;
                case 9:
                    this.SetDamage(9);
                    break;
                case 10:
                    this.SetDamage(10);
                    break;
                case 11:
                    this.SetDamage(11);
                    break;
                case 12:
                    this.SetDamage(12);
                    break;
                case 13:
                    this.SetDamage(13);
                    break;
                case 14:
                    this.SetDamage(14);
                    break;
                default:
                    break;
            }
        }
        override protected void AdjustCriticalDamage()
        {
            switch (this.GetLevel())
            {
                case 0:
                    this.SetCriticalDamage(0);
                    break;
                case 1:
                    this.SetCriticalDamage(1);
                    break;
                case 2:
                    this.SetCriticalDamage(1);
                    break;
                case 3:
                    this.SetCriticalDamage(3);
                    break;
                case 4:
                    this.SetCriticalDamage(4);
                    break;
                case 5:
                    this.SetCriticalDamage(5);
                    break;
                case 6:
                    this.SetCriticalDamage(6);
                    break;
                case 7:
                    this.SetCriticalDamage(7);
                    break;
                case 8:
                    this.SetCriticalDamage(8);
                    break;
                case 9:
                    this.SetCriticalDamage(9);
                    break;
                case 10:
                    this.SetCriticalDamage(10);
                    break;
                case 11:
                    this.SetCriticalDamage(11);
                    break;
                case 12:
                    this.SetCriticalDamage(12);
                    break;
                case 13:
                    this.SetCriticalDamage(13);
                    break;
                case 14:
                    this.SetCriticalDamage(14);
                    break;
                default:
                    break;
            }

        }
        override protected void AdjustCriticalPercentage()
        {
            switch (this.GetLevel())
            {
                case 0:
                    this.SetCriticalPercentage(0);
                    break;
                case 1:
                    this.SetCriticalPercentage(1);
                    break;
                case 2:
                    this.SetCriticalPercentage(2);
                    break;
                case 3:
                    this.SetCriticalPercentage(3);
                    break;
                case 4:
                    this.SetCriticalPercentage(4);
                    break;
                case 5:
                    this.SetCriticalPercentage(5);
                    break;
                case 6:
                    this.SetCriticalPercentage(6);
                    break;
                case 7:
                    this.SetCriticalPercentage(7);
                    break;
                case 8:
                    this.SetCriticalPercentage(8);
                    break;
                case 9:
                    this.SetCriticalPercentage(9);
                    break;
                case 10:
                    this.SetCriticalPercentage(10);
                    break;
                case 11:
                    this.SetCriticalPercentage(11);
                    break;
                case 12:
                    this.SetCriticalPercentage(12);
                    break;
                case 13:
                    this.SetCriticalPercentage(13);
                    break;
                case 14:
                    this.SetCriticalPercentage(14);
                    break;
                default:
                    break;
            }
        }
    }
}
