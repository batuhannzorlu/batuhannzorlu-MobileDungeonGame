using Assets.Scripts.Classes.ITEM.WEAPON;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CompareInventorySword : MonoBehaviour
{
    public Sprite Up;
    public Sprite Down;
    public Sprite InSlotItemImg;
    public Sprite CurrentItemImg;
    public string PlayerTag;
    GameObject Player;
    Inventory PlayerInventory;
    Sprite[] ItemImg;
    Sword sword;
    Sword Currentsword;
    Sword InSlotsword;

    public int SlotNumber;
    private void Start()
    {
        Compare();
    }
    //private void Update() { Compare(); }

    public void Compare()
    {
        sword = new Sword();
        Player = GameObject.FindWithTag(PlayerTag).gameObject;
        PlayerInventory = Player.GetComponent<Inventory>();

        Dictionary<Sprite, int> dictionary = new Dictionary<Sprite, int>();
        dictionary = sword.FindItemWithObj(Player.transform.GetChild(1).Find("biped:mr:skeleton").Find("biped:mr:root_jnt").Find("biped:mr:spine_01_jnt").
                    Find("biped:mr:spine_02_jnt").Find("biped:mr:R_Arm_Clavicle_jnt").Find("biped:mr:R_Arm_Shoulder_jnt").Find("biped:mr:R_elbow_jnt").
                    Find("biped:mr:R_wrist_jnt").Find("biped:mr:R_WeaponAttachMent_jnt").transform.GetChild(0).gameObject);
        foreach (KeyValuePair<Sprite, int> Img in dictionary) { CurrentItemImg = Img.Key; }

        Currentsword = new Sword(CurrentItemImg);
        InSlotsword = new Sword(InSlotItemImg);
        if (Currentsword.GetLevel() > InSlotsword.GetLevel())
        {
            this.GetComponent<Image>().color = Color.red;
            this.GetComponent<Image>().sprite = Down;
        }
        //else if (Currentsword.GetLevel() == InSlotsword.GetLevel())
        //{
        //    Destroy(this.gameObject);
        //}
        else
        {
            this.GetComponent<Image>().color = Color.green;
            this.GetComponent<Image>().sprite = Up;
        }



    }

}
