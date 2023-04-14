using System.Collections.Generic;
using UnityEngine;

namespace ShopSystem
{
    public class Shop : Container
    {
        public CanvasGroup shopUI;
        public GameObject itemPrefab;
        public List<ItemScriptable> ShopItemsScriptable = new List<ItemScriptable>();

        [HideInInspector]
        public ShopKeeper shopKeeper;

        private void Awake() 
        {
            shopUI = GetComponent<CanvasGroup>();
            // Populate the shop with items
            PopulateShop();
        }


        /// <summary>
        /// Open or close the shop UI
        /// </summary>
        public void OpenShop(bool flag)
        {
            shopUI.alpha = flag ? 1 : 0;
            shopUI.interactable = flag;
            shopUI.blocksRaycasts = flag;
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
                // assign the shopkeeper of this shop to the item
                itemComponent.shopKeeper = shopKeeper;
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

