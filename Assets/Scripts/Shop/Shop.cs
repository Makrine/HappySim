using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ShopSystem
{
    /// <summary>
    /// This class handles the shop UI and the items that are in the shop.
    /// </summary>
    public class Shop : Container
    {
        public string shopKeeperTag = "ShopKeeper1";
        public CanvasGroup shopUI;
        public GameObject itemPrefab;
        public List<ItemScriptable> ShopItemsScriptable = new List<ItemScriptable>();

        [HideInInspector]
        public ShopKeeper shopKeeper;

        public bool IsOpen => shopUI.interactable;

        public Button close;
        public DoTweensManager uimanager = new();

        private void Awake() 
        {
            shopUI = GetComponent<CanvasGroup>();
            close.onClick.AddListener(() => OpenShop(false));
            // Populate the shop with items
            PopulateShop();
        }


        /// <summary>
        /// Open or close the shop UI
        /// </summary>
        public void OpenShop(bool flag)
        {
            if(flag)
                uimanager.FadeInPanel();
            else
                uimanager.FadeOutPanel();
            shopKeeper.inventory.OpenInventory(flag);
            //shopUI.alpha = flag ? 1 : 0;
            shopUI.interactable = flag;
            shopUI.blocksRaycasts = flag;
        }

        /// <summary>
        /// Populate the shop with items. This method assumes that the itemsContainer is empty
        /// and has a GridLayoutGroup component attached to it.
        /// </summary>
        private void PopulateShop()
        {
            shopKeeper = GameObject.FindGameObjectWithTag(shopKeeperTag).GetComponent<ShopKeeper>();
            foreach (var item in ShopItemsScriptable)
            {
                // Create a new item instance GO and set its parent to the itemsContainer
                GameObject itemInstance = Instantiate(itemPrefab, itemsContainer);
                // Add the Item component to the item instance
                Item itemComponent = itemInstance.GetComponent<Item>();
                // assign the shopkeeper of this shop to the item
                Debug.Log("Shopkeeper from Item: " + shopKeeper);
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

