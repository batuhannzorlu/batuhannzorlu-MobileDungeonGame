using Assets.Scripts.Classes.ITEM.ARMOR;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class BerserkerShieldInventoryButton : MonoBehaviour, IPointerDownHandler
{

    public GameObject compareItem;
    Sprite BerserkerSwordImg;
    Shield shield;
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
        shield = new Shield(BerserkerSwordImg);

        Dictionary<GameObject, int> dictionary = new Dictionary<GameObject, int>();
        dictionary = shield.GetArmorWImg(BerserkerSwordImg);
        foreach (KeyValuePair<GameObject, int> Img in dictionary)
        {
            GameObject Shield;

            Shield = player.transform.GetChild(1).Find("biped:mr:skeleton").Find("biped:mr:root_jnt").Find("biped:mr:spine_01_jnt").
                Find("biped:mr:spine_02_jnt").Find("biped:mr:L_Arm_Clavicle_jnt").Find("biped:mr:L_Arm_Shoulder_jnt").Find("biped:mr:L_elbow_jnt").
                Find("biped:mr:L_wrist_jnt").Find("biped:mr:L_Shield_AttachMent_jnt").transform.GetChild(0).gameObject;

            Dictionary<Sprite, int> dictionary_1 = new Dictionary<Sprite, int>();
            dictionary_1 = shield.FindItemWithObj(Shield);
            foreach (KeyValuePair<Sprite, int> Obj in dictionary_1)
            {
                this.GetComponent<Image>().sprite = Obj.Key;
            }
            //for (int i = 0; i < player.GetComponent<Inventory>().Slots.Length; i++)
            //{
            //    if (player.GetComponent<Inventory>().Slots[i].transform.childCount == 3)
            //    {
            //        if (player.GetComponent<Inventory>().Slots[i].transform.GetChild(0).GetComponent<Image>().sprite.name.StartsWith("Shield"))
            //            player.GetComponent<Inventory>().Slots[i].transform.GetChild(2).GetComponent<CompareInventorySword>().Compare();
            //    }
            //}
            player.GetComponent<SetupLocalPlayer>().CmdChangeShieldState("", Img.Key.name,"OutUpdateArmor");


        }
    }
}
