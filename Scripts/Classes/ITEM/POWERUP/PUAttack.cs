using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Classes.ITEM.POWERUP
{
    public class PUAttack : PowerUp
    {
        private float BonusAttack { get; set; }


        public PUAttack(GameObject _ReferencePowerup)
        {
            const string PathPowerupObj = "GameAssetInScene/ITEM/POWERUP/_POWERUP/ATTACK";
            const string PathPowerupImg = "GameAssetInScene/ItemSprite/PowerUpSprite/Attack";
            this.LoadAssets(this.GetType(), PathPowerupObj, PathPowerupImg);
            this.IsCaptured = false;
            this.SetPowerUpFeatures(_ReferencePowerup);
        }

        public float GetBonusAttack() { return this.BonusAttack; }

        public void SetBonusAttack(float _BonusAttack) { this.BonusAttack=_BonusAttack; }
        override public void  AdjustFeature()
        {
            switch (this.GetLevel())
            {
                case 0:
                    this.SetBonusAttack(5);
                    break;
                case 1:
                    this.SetBonusAttack(10);
                    break;
                default:
                    break;
            }
        }




    }
}
