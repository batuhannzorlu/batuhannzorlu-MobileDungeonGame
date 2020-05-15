using Assets.Scripts.Classes.ITEM.ARMOR;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Mirror;
public class BerserkerArmorInventoryButton : NetworkBehaviour, IPointerDownHandler
{

    Sprite BerserkerArmorImg;
    ArBerserker arBerserker;
    public string PlayerTag;
    GameObject player;
    void Start()
    {
        player = GameObject.FindWithTag(PlayerTag).gameObject;

    }

    public void OnPointerDown(PointerEventData eventData)
    {
        BerserkerArmorImg = this.GetComponent<Image>().sprite;
        arBerserker = new ArBerserker(BerserkerArmorImg);

        Dictionary<GameObject, int> dictionary = new Dictionary<GameObject, int>();
        dictionary = arBerserker.FindItemWithImg(BerserkerArmorImg);
        foreach (KeyValuePair<GameObject, int> Img in dictionary)
        {
            Transform WeaponHand;
            Transform ShieldHand;
            GameObject Weapon;
            GameObject Shield;


            //Weapon = player.transform.GetChild(1).Find("biped:mr:skeleton").Find("biped:mr:root_jnt").Find("biped:mr:spine_01_jnt").
            //        Find("biped:mr:spine_02_jnt").Find("biped:mr:R_Arm_Clavicle_jnt").Find("biped:mr:R_Arm_Shoulder_jnt").Find("biped:mr:R_elbow_jnt").
            //        Find("biped:mr:R_wrist_jnt").Find("biped:mr:R_WeaponAttachMent_jnt").transform.GetChild(0).gameObject;

            //Shield = player.transform.GetChild(1).Find("biped:mr:skeleton").Find("biped:mr:root_jnt").Find("biped:mr:spine_01_jnt").
            //        Find("biped:mr:spine_02_jnt").Find("biped:mr:L_Arm_Clavicle_jnt").Find("biped:mr:L_Arm_Shoulder_jnt").Find("biped:mr:L_elbow_jnt").
            //        Find("biped:mr:L_wrist_jnt").Find("biped:mr:L_Shield_AttachMent_jnt").GetChild(0).gameObject;

            Dictionary<Sprite, int> dictionary_1 = new Dictionary<Sprite, int>();
            dictionary_1 = arBerserker.FindItemWithObj(player.transform.GetChild(1).gameObject);
            foreach (KeyValuePair<Sprite, int> Obj in dictionary_1)
            {
                this.GetComponent<Image>().sprite = Obj.Key;
            }

            //Destroy(player.transform.GetChild(1).gameObject);
            //GameObject clonearmor = Instantiate(Img.Key, player.transform.position, player.transform.rotation, player.transform) as GameObject;
            //clonearmor.name = Img.Key.name;
            player.GetComponent<SetupLocalPlayer>().CmdChangeArmorState("", Img.Key.name);

            //     WeaponHand = clonearmor.transform.Find("biped:mr:skeleton").Find("biped:mr:root_jnt").Find("biped:mr:spine_01_jnt").
            //Find("biped:mr:spine_02_jnt").Find("biped:mr:R_Arm_Clavicle_jnt").Find("biped:mr:R_Arm_Shoulder_jnt").Find("biped:mr:R_elbow_jnt").
            //Find("biped:mr:R_wrist_jnt").Find("biped:mr:R_WeaponAttachMent_jnt").transform;

            //     ShieldHand = clonearmor.transform.Find("biped:mr:skeleton").Find("biped:mr:root_jnt").Find("biped:mr:spine_01_jnt").
            //             Find("biped:mr:spine_02_jnt").Find("biped:mr:L_Arm_Clavicle_jnt").Find("biped:mr:L_Arm_Shoulder_jnt").Find("biped:mr:L_elbow_jnt").
            //             Find("biped:mr:L_wrist_jnt").Find("biped:mr:L_Shield_AttachMent_jnt").transform;

            //GameObject CloneWeapon = Instantiate(Weapon, WeaponHand.transform.position, WeaponHand.transform.rotation, WeaponHand.transform);
            //CloneWeapon.name = Weapon.name;

            //GameObject CloneShield = Instantiate(Shield, ShieldHand.transform.position, ShieldHand.transform.rotation, ShieldHand.transform);
            //CloneShield.name = Shield.name;

            //player.GetComponent<SetupLocalPlayer>().PlayerAnimator = clonearmor.GetComponent<Animator>();
        }
    }
}
