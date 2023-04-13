using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ShopSystem
{
    public class Shop : Container
    {
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
                // Create a new item instance GO
                GameObject itemInstance = new("Item_" + item.itemName);
                // Set the parent of the item instance to the items container
                itemInstance.transform.SetParent(itemsContainer);
                // Add the Image component to the item instance
                Image img = itemInstance.AddComponent<Image>();
                // Set the sprite of the item instance to the item sprite
                img.sprite = item.itemSpriteUI;
                // Add Button component to the item instance
                Button btn = itemInstance.AddComponent<Button>();
                btn.targetGraphic = img;
                // Add the Item component to the item instance
                Item itemComponent = itemInstance.AddComponent<Item>();
                // Set the itemScriptable of the item instance to the item
                itemComponent.itemScriptable = item;
                // Set the itemState of the item instance to InShop
                itemComponent.itemState = ItemState.InShop;

                Items.Add(itemComponent);
            }
        }
        
    }
}

