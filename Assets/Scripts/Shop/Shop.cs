using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ShopSystem
{
    public class Shop : Container
    {
        public GameObject itemPrefab;
        public List<ItemScriptable> ShopItemsScriptable = new List<ItemScriptable>();


        private void Awake() 
        {
            // Populate the shop with items
            PopulateShop();
        }

        /// <summary>
        /// Populate the shop with items. This method assumes that the itemsContainer is empty
        /// and has a GridLayoutGroup component attached to it.
        /// </summary>
        private void PopulateShop()
        {
            foreach (var item in ShopItemsScriptable)
            {
                // Create a new item instance GO and set its parent to the itemsContainer
                GameObject itemInstance = Instantiate(itemPrefab, itemsContainer);
                // Add the Item component to the item instance
                Item itemComponent = itemInstance.GetComponent<Item>();
                // Set the itemScriptable of the item instance to the item
                itemComponent.itemScriptable = item;
                // Set the itemState of the item instance to InShop
                itemComponent.itemState = ItemState.InShop;
                itemComponent.img.sprite = item.itemSpriteUI;
                itemComponent.itemName.text = item.itemName;
                itemComponent.price = item.price;
                itemComponent.price_txt.text = itemComponent.price.ToString();

                Items.Add(itemComponent);
            }
        }
        
    }
}

