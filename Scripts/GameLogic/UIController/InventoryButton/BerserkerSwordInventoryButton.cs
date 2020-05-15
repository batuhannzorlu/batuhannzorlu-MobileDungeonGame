using Assets.Scripts.Classes.ITEM.WEAPON;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class BerserkerSwordInventoryButton : MonoBehaviour, IPointerDownHandler
{
    public GameObject compareItem;
    Sprite BerserkerSwordImg;
    Sword sword;
    public string PlayerTag;
    GameObject player;
    public delegate void InventoryCompare();
    void Start()
    {

        player = GameObject.FindWithTag(PlayerTag).gameObject;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        BerserkerSwordImg = this.GetComponent<Image>().sprite;
        sword = new Sword(BerserkerSwordImg);

        Dictionary<GameObject, int> dictionary = new Dictionary<GameObject, int>();
        dictionary = sword.GetWeaponWImg(BerserkerSwordImg);
        foreach (KeyValuePair<GameObject, int> Img in dictionary)
        {
            GameObject Weapon;

            Weapon = player.transform.GetChild(1).Find("biped:mr:skeleton").Find("biped:mr:root_jnt").Find("biped:mr:spine_01_jnt").
                    Find("biped:mr:spine_02_jnt").Find("biped:mr:R_Arm_Clavicle_jnt").Find("biped:mr:R_Arm_Shoulder_jnt").Find("biped:mr:R_elbow_jnt").
                    Find("biped:mr:R_wrist_jnt").Find("biped:mr:R_WeaponAttachMent_jnt").transform.GetChild(0).gameObject;

            Dictionary<Sprite, int> dictionary_1 = new Dictionary<Sprite, int>();
            dictionary_1 = sword.FindItemWithObj(Weapon);
            foreach (KeyValuePair<Sprite, int> Obj in dictionary_1)
            {
                this.GetComponent<Image>().sprite = Obj.Key;
            }
            //for (int i = 0; i < player.GetComponent<Inventory>().Slots.Length; i++)
            //{
            //    if (player.GetComponent<Inventory>().Slots[i].transform.childCount == 3)
            //    {
            //        if (player.GetComponent<Inventory>().Slots[i].transform.GetChild(0).GetComponent<Image>().sprite.name.StartsWith("Sword"))
            //            player.GetComponent<Inventory>().Slots[i].transform.GetChild(2).GetComponent<CompareInventorySword>().Compare();
            //    }
            //}
            player.GetComponent<SetupLocalPlayer>().CmdChangeWeaponState("",Img.Key.name,"OutUpdateArmor");


        }
    }

}
