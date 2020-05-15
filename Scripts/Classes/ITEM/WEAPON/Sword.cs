using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Classes.ITEM.WEAPON
{
    public class Sword : Weapon
    {

        const string PathArmorImg = "GameAssetInScene/ItemSprite/Swords";

        private float FireAmount { get; set; }
        private float FirePercentage { get; set; }

        public Sword(GameObject _ReferenceSword)
        {
            const string PathArmorObj = "GameAssetInScene/ITEM/WEAPON/SWORD/ONPLAYER";
            this.SetType("Sword");
            this.LoadAssets(this.GetType(), PathArmorObj, PathArmorImg);
            this.IsCaptured = false;
            this.SetWeaponFeatures(_ReferenceSword);
            AdjustFirePercentage();
            this.UnLoadAssets();
        }

        public Sword()
        {
            const string PathArmorObj = "GameAssetInScene/ITEM/WEAPON/SWORD/ONPLAYER";
            this.SetType("Sword");
            this.LoadAssets(this.GetType(), PathArmorObj, PathArmorImg);
            this.IsCaptured = true;
            this.SetWeaponFeatures(this.GetDefaultWeapon());
            AdjustFirePercentage();
            this.UnLoadAssets();
        }
        public Sword(Sprite _ReferenceSword)
        {
            const string PathArmorObj = "GameAssetInScene/ITEM/WEAPON/SWORD/ONPLAYER";
            this.SetType("ArBerserker");
            this.LoadAssets(this.GetType(), PathArmorObj, PathArmorImg);
            this.IsCaptured = false;
            SetWeaponFeaturesWImg(_ReferenceSword);
            this.UnLoadAssets();
        }

        public float GetFireAmount() { return FireAmount; }
        public float GetFirePercentage() { return FirePercentage; }

        protected void SetFireAmount(float _FireAmount) { this.FireAmount = _FireAmount; }
        protected void SetFirePercentage(float _FirePercentage) { this.FirePercentage = _FirePercentage; }

        override protected void AdjustDamage()
        {
            switch (this.GetLevel())
            {
                case 0:
                    this.SetDamage(20);
                    break;
                case 1:
                    this.SetDamage(30);
                    break;
                case 2:
                    this.SetDamage(40);
                    break;
                case 3:
                    this.SetDamage(50);
                    break;
                case 4:
                    this.SetDamage(60);
                    break;
                case 5:
                    this.SetDamage(70);
                    break;
                case 6:
                    this.SetDamage(80);
                    break;
                case 7:
                    this.SetDamage(90);
                    break;
                case 8:
                    this.SetDamage(95);
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
                    this.SetCriticalDamage(13);
                    break;
                case 1:
                    this.SetCriticalDamage(15);
                    break;
                case 2:
                    this.SetCriticalDamage(16);
                    break;
                case 3:
                    this.SetCriticalDamage(17);
                    break;
                case 4:
                    this.SetCriticalDamage(19);
                    break;
                case 5:
                    this.SetCriticalDamage(20);
                    break;
                case 6:
                    this.SetCriticalDamage(21);
                    break;
                case 7:
                    this.SetCriticalDamage(23);
                    break;
                case 8:
                    this.SetCriticalDamage(25);
                    break;
                case 9:
                    this.SetCriticalDamage(27);
                    break;
                case 10:
                    this.SetCriticalDamage(29);
                    break;
                case 11:
                    this.SetCriticalDamage(31);
                    break;
                case 12:
                    this.SetCriticalDamage(32);
                    break;
                case 13:
                    this.SetCriticalDamage(35);
                    break;
                case 14:
                    this.SetCriticalDamage(38);
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
                    this.SetCriticalPercentage(7);
                    break;
                case 1:
                    this.SetCriticalPercentage(9);
                    break;
                case 2:
                    this.SetCriticalPercentage(11);
                    break;
                case 3:
                    this.SetCriticalPercentage(17);
                    break;
                case 4:
                    this.SetCriticalPercentage(19);
                    break;
                case 5:
                    this.SetCriticalPercentage(21);
                    break;
                case 6:
                    this.SetCriticalPercentage(26);
                    break;
                case 7:
                    this.SetCriticalPercentage(29);
                    break;
                case 8:
                    this.SetCriticalPercentage(33);
                    break;
                case 9:
                    this.SetCriticalPercentage(35);
                    break;
                case 10:
                    this.SetCriticalPercentage(37);
                    break;
                case 11:
                    this.SetCriticalPercentage(39);
                    break;
                case 12:
                    this.SetCriticalPercentage(43);
                    break;
                case 13:
                    this.SetCriticalPercentage(45);
                    break;
                case 14:
                    this.SetCriticalPercentage(50);
                    break;
                default:
                    break;
            }
        }

        override public GameObject GetDefaultWeapon()
        {
            return (GameObject)(Resources.Load("GameAssetInScene/ITEM/WEAPON/SWORD/ONPLAYER/weapon_sword_1 Variant"));
        }


        private void AdjustFirePercentage()
        {

            switch (this.GetLevel())
            {
                case 0:
                    this.SetFirePercentage(8f);
                    break;
                case 1:
                    this.SetFirePercentage(12f);
                    break;
                case 2:
                    this.SetFirePercentage(13f);
                    break;
                case 3:
                    this.SetFirePercentage(14f);
                    break;
                case 4:
                    this.SetFirePercentage(15f);
                    break;
                case 5:
                    this.SetFirePercentage(15f);
                    break;
                case 6:
                    this.SetFirePercentage(16f);
                    break;
                case 7:
                    this.SetFirePercentage(17f);
                    break;
                case 8:
                    this.SetFirePercentage(18f);
                    break;
                case 9:
                    this.SetFirePercentage(19f);
                    break;
                case 10:
                    this.SetFirePercentage(20f);
                    break;
                case 11:
                    this.SetFirePercentage(20f);
                    break;
                case 12:
                    this.SetFirePercentage(21f);
                    break;
                case 13:
                    this.SetFirePercentage(25f);
                    break;
                case 14:
                    this.SetFirePercentage(28f);
                    break;
                default:
                    break;
            }

        }
        private void AdjustFireAmount()
        {

            switch (this.GetLevel())
            {
                case 0:
                    this.SetFireAmount(1);
                    break;
                case 1:
                    this.SetFireAmount(1);
                    break;
                case 2:
                    this.SetFireAmount(1);
                    break;
                case 3:
                    this.SetFireAmount(1);
                    break;
                case 4:
                    this.SetFireAmount(1);
                    break;
                case 5:
                    this.SetFireAmount(1);
                    break;
                case 6:
                    this.SetFireAmount(1);
                    break;
                case 7:
                    this.SetFireAmount(1);
                    break;
                case 8:
                    this.SetFireAmount(1);
                    break;
                case 9:
                    this.SetFireAmount(1);
                    break;
                case 10:
                    this.SetFireAmount(1);
                    break;
                case 11:
                    this.SetFireAmount(1);
                    break;
                case 12:
                    this.SetFireAmount(1);
                    break;
                case 13:
                    this.SetFireAmount(1);
                    break;
                case 14:
                    this.SetFireAmount(1);
                    break;
                default:
                    break;
            }

        }
    }
}
