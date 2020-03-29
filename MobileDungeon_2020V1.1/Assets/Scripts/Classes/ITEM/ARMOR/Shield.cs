using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Classes.ITEM.ARMOR
{
    public class Shield : Armor
    {
        const string PathArmorImg = "GameAssetInScene/ItemSprite/Shields";
        public Shield(GameObject _ReferenceShield)
        {
            const string PathArmorObj = "GameAssetInScene/ITEM/ARMOR/SHIELD/ONDROP";
            this.SetType("Shield");
            this.LoadAssets(this.GetType(), PathArmorObj, PathArmorImg);
            this.IsCaptured = false;
            SetArmorFeatures(_ReferenceShield);
            this.UnLoadAssets();
        }

        public Shield()
        {
            const string PathArmorObj = "GameAssetInScene/ITEM/ARMOR/SHIELD/ONPLAYER";
            this.SetType("Shield");
            this.LoadAssets(this.GetType(), PathArmorObj, PathArmorImg);
            this.IsCaptured = false;
            SetArmorFeatures(this.GetDefaultArmor());
            this.UnLoadAssets();
        }
        override public GameObject GetDefaultArmor()
        {
            return (GameObject)(Resources.Load("GameAssetInScene/ITEM/ARMOR/SHIELD/ONPLAYER/weapon_shield_bronze_1 Variant"));
        }
        protected override void AdjustDefense()
        {

            switch (this.GetLevel())
            {
                case 0:
                    this.SetDefense(1);
                    break;
                case 1:
                    this.SetDefense(2);
                    break;
                case 2:
                    this.SetDefense(3);
                    break;
                case 3:
                    this.SetDefense(4);
                    break;
                case 4:
                    this.SetDefense(5);
                    break;
                case 5:
                    this.SetDefense(6);
                    break;
                case 6:
                    this.SetDefense(7);
                    break;
                case 7:
                    this.SetDefense(8);
                    break;
                case 8:
                    this.SetDefense(9);
                    break;
                default:
                    break;
            }

        }
    }
}
