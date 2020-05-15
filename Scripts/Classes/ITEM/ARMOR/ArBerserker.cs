using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Classes.ITEM.ARMOR
{
    public class ArBerserker : Armor
    {

        const string PathArmorImg = "GameAssetInScene/ItemSprite/SwordAndHammerArmors";

        public ArBerserker(GameObject _ReferenceArmor)
        {
            const string PathArmorObj = "GameAssetInScene/ITEM/ARMOR/BERSERKER/ONPLAYER";
            this.SetType("ArBerserker");
            this.LoadAssets(this.GetType(), PathArmorObj, PathArmorImg);
            this.IsCaptured = false;
            SetArmorFeatures(_ReferenceArmor);
            this.UnLoadAssets();
        }
        public ArBerserker()
        {
            const string PathArmorObj = "GameAssetInScene/ITEM/ARMOR/BERSERKER/ONPLAYER";
            this.SetType("ArBerserker");
            this.LoadAssets(this.GetType(), PathArmorObj, PathArmorImg);
            this.IsCaptured = true;
            SetArmorFeatures(this.GetDefaultArmor());
            this.UnLoadAssets();
        }
        public ArBerserker(Sprite _ReferenceArmor)
        {
            const string PathArmorObj = "GameAssetInScene/ITEM/ARMOR/BERSERKER/ONPLAYER";
            this.SetType("ArBerserker");
            this.LoadAssets(this.GetType(), PathArmorObj, PathArmorImg);
            this.IsCaptured = false;
            SetArmorFeaturesWImg(_ReferenceArmor);
            this.UnLoadAssets();
        }

        public override GameObject GetDefaultArmor()
        {
            return (GameObject)(Resources.Load("GameAssetInScene/ITEM/ARMOR/BERSERKER/ONPLAYER/body_rags_bronze_common Variant"));
        }
        protected override void AdjustDefense()
        {

            switch (this.GetLevel())
            {
                case 0:
                    this.SetDefense(30);
                    break;
                case 1:
                    this.SetDefense(44);
                    break;
                case 2:
                    this.SetDefense(58);
                    break;
                case 3:
                    this.SetDefense(90);
                    break;
                case 4:
                    this.SetDefense(118);
                    break;
                case 5:
                    this.SetDefense(146);
                    break;
                case 6:
                    this.SetDefense(150);
                    break;
                case 7:
                    this.SetDefense(160);
                    break;
                case 8:
                    this.SetDefense(202);
                    break;
                default:
                    break;
            }

        }

    }
}
