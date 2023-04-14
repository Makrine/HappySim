using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ShopSystem;
using System;

public class Equipment : Container
{
    public GameObject itemPrefab;
    public List<ItemScriptable> equippedItemsScriptable = new();
    
    private void Start()
    {
        // Populate the equipment with items
        PopulateEquipment();
    }

    private void PopulateEquipment()
    {
        foreach (var item in equippedItemsScriptable)
            {
                // Create a new item instance GO and set its parent to the itemsContainer
                GameObject itemInstance = Instantiate(itemPrefab, itemsContainer);
                // Add the Item component to the item instance
                Item itemComponent = itemInstance.GetComponent<Item>();
                // assign the shopkeeper of this shop to the item
                itemComponent.shopKeeper = GameObject.FindGameObjectWithTag("ClothesShopKeeper1").GetComponent<ShopKeeper>();
                // Set the itemScriptable of the item instance to the item
                itemComponent.itemScriptable = item;
                // Set the itemState of the item instance to InShop
                itemComponent.equiomentChanger = GetComponentInChildren<EquipmentChanger>();
                itemComponent.itemState = ItemState.Equipped;
                itemComponent.img.sprite = item.itemSpriteUI;
                itemComponent.itemName.text = item.itemName;
                itemComponent.price = item.price;
                itemComponent.price_txt.text = itemComponent.price.ToString();
                

                Items.Add(itemComponent);
            }
    }
}
