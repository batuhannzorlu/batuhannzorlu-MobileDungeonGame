using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SlotInventoryButton : MonoBehaviour
{
    public GameObject DropSound;
    private Inventory inventory;
    public string PlayerTag;
    public int i;

    void Start()
    {
        inventory = GameObject.FindWithTag(PlayerTag).GetComponent<Inventory>();
    }
    void Update()
    {
        if (transform.childCount <= 0)
            inventory.isFull[i] = false;
    }
    public void DropItem()
    {
        foreach (Transform child in transform)
        {
            GameObject.Destroy(child.gameObject);
        }
        Instantiate(DropSound, Vector3.zero, Quaternion.identity);
    }



}
