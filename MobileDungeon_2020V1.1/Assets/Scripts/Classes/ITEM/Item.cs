using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Classes.ITEM
{
    public class Item
    {
        protected GameObject[] ItemObj { get; set; } = null;
        protected Sprite[] ItemImg { get; set; } = null;

        private string Type { get; set; } = null;
        private int Level { get; set; } = 0;
        public bool IsCaptured { get; set; } = false;

        public int GetLevel() { return Level; }
        public new string GetType() { return Type; }
        public Sprite GetSprite() { return ItemImg[this.Level]; }
        public string GetObjectName() { return ItemObj[this.Level].name; }


        protected void LoadAssets(string _type, string _FilePathObj, string _FilePathImg)
        {
            if (_type == "ArCrossBow" || _type == "ArBerserker" || _type == "Hammer" || _type == "Bow" || _type == "PowerUp" || _type == "Pet" || _type == "Sword" || _type == "Shield")
            {
                this.ItemImg = Resources.LoadAll<Sprite>(_FilePathImg);
                this.ItemObj = Resources.LoadAll<GameObject>(_FilePathObj);
            }
        }
        protected void UnLoadAssets() { Resources.UnloadUnusedAssets(); }

        protected void SetLevel(int _Level) { this.Level = _Level; }
        protected void SetType(string _Type) { this.Type = _Type; }

        public Dictionary<Sprite, int> FindItemWithObj(GameObject _ItemObj)
        {
            Dictionary<Sprite, int> dictionary = new Dictionary<Sprite, int>();
            for (int i = 0; i < ItemObj.Length; i++)
            {
                if (ItemObj[i].name == _ItemObj.name)
                {
                    this.Level = i;
                    dictionary.Add(ItemImg[i], i);
                    return dictionary;

                }
            }
            return null;
        }
        public Dictionary<GameObject, int> FindItemWithImg(Sprite _ItemImg)
        {
            Dictionary<GameObject, int> dictionary = new Dictionary<GameObject, int>();
            for (int i = 0; i < ItemImg.Length; i++)
            {
                if (ItemImg[i].name == _ItemImg.name)
                {
                    this.Level = i;
                    dictionary.Add(ItemObj[i], i);
                    return dictionary;
                }
            }
            return null;
        }
    }
}
