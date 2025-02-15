﻿using Assets.Scripts.Classes.ITEM.ARMOR;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickUpArmorBerserker : MonoBehaviour
{
    public GameObject RemoveItemButton;
    public GameObject TakeArmor;
    private Inventory inventory;
    public GameObject itemButton;
    GameObject canvas;
    public ArBerserker ReferenceArmor;
    private void Start()
    {
        ReferenceArmor = new ArBerserker(this.gameObject);
    }

    private void OnTriggerEnter(Collider _Player)
    {

        if (_Player.gameObject.tag.StartsWith("Player"))
        {
            inventory = GameObject.FindGameObjectWithTag(_Player.gameObject.tag).GetComponent<Inventory>();
            for (int i = 0; i < inventory.Slots.Length; i++)
            {
                if (inventory.isFull[i] == false)
                {
                    Dictionary<Sprite, int> dictionary = new Dictionary<Sprite, int>();
                    dictionary = ReferenceArmor.FindItemWithObj(this.gameObject);
                    foreach (KeyValuePair<Sprite, int> Img in dictionary)
                    {
                        itemButton.GetComponent<BerserkerArmorInventoryButton>().PlayerTag = inventory.Owner;
                        itemButton.GetComponent<Image>().sprite = Img.Key;
                        Instantiate(TakeArmor, Vector3.zero, Quaternion.identity);
                    }
                    inventory.isFull[i] = true;
                    GameObject _itembutton = Instantiate(itemButton, inventory.Slots[i].transform, false);
                    GameObject _RemoveItembutton = Instantiate(RemoveItemButton, inventory.Slots[i].transform, false);

                    _RemoveItembutton.GetComponent<Button>().onClick.RemoveAllListeners();
                    _RemoveItembutton.GetComponent<Button>().onClick.AddListener(delegate { inventory.Slots[i].gameObject.GetComponent<SlotInventoryButton>().DropItem(); });
                    Destroy(gameObject);
                    break;
                }
            }
        }

    }
}
