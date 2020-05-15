using Assets.Scripts.Classes.ITEM.WEAPON;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class PickUpSword : MonoBehaviour
{
    public GameObject CompareItem;
    public GameObject RemoveItem;
    public GameObject TakeArmor;
    private Inventory inventory;
    public GameObject itemButton;
    GameObject canvas;
    public Sword ReferenceSword;
    private void Start()
    {
        ReferenceSword = new Sword(this.gameObject);
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
                    dictionary = ReferenceSword.FindItemWithObj(this.gameObject);
                    foreach (KeyValuePair<Sprite, int> Img in dictionary)
                    {
                        itemButton.GetComponent<BerserkerSwordInventoryButton>().PlayerTag = inventory.Owner;
                        CompareItem.GetComponent<CompareInventorySword>().PlayerTag = inventory.Owner;
                        CompareItem.GetComponent<CompareInventorySword>().InSlotItemImg = Img.Key;

                        itemButton.GetComponent<Image>().sprite = Img.Key;
                        Instantiate(TakeArmor, Vector3.zero, Quaternion.identity);
                    }
                    inventory.isFull[i] = true;
                    GameObject _itembutton = Instantiate(itemButton, inventory.Slots[i].transform, false);
                    GameObject _RemoveItem = Instantiate(RemoveItem, inventory.Slots[i].transform, false);
                    GameObject _CompareItem = Instantiate(CompareItem, inventory.Slots[i].transform, false);
                    _RemoveItem.GetComponent<Button>().onClick.RemoveAllListeners();
                    _RemoveItem.GetComponent<Button>().onClick.AddListener(delegate { inventory.Slots[i].gameObject.GetComponent<SlotInventoryButton>().DropItem(); });
                    Destroy(gameObject);
                    break;
                }
            }
        }

    }
}
