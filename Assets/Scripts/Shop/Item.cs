using UnityEngine;
using UnityEngine.UI;

namespace ShopSystem
{
    public class Item : MonoBehaviour
    {
        public ItemScriptable itemScriptable;
        public Image img;
        public Button btn;
        public TMPro.TMP_Text itemName;
        public TMPro.TMP_Text price_txt;
        [HideInInspector]
        public int price;

        public ItemState itemState; // The state of the item

        // References
        public ShopKeeper shopKeeper;

        [HideInInspector]
        public EquiomentChanger equiomentChanger;

        private void Start()
        {
            // Add a listener to the button click event
            btn.onClick.AddListener(HandleItemClick);
        }


        /// <summary>
        /// Handle the click event of the item
        /// If the item is in shop, it addes it to the cart
        /// If the item is in cart, it removes it from the cart and adds it to the shop
        /// If the item is in inventory, it removes it sells it
        /// </summary>
        private void HandleItemClick()
        {
            if(itemState == ItemState.InShop)
            {
                // Add item to cart
                shopKeeper.cart.AddItem(this, ItemState.InCart);
                shopKeeper.shop.RemoveItem(this);
            }
            else if(itemState == ItemState.InCart)
            {
                shopKeeper.shop.AddItem(this, ItemState.InShop);
                // Remove item from cart
                shopKeeper.cart.RemoveItem(this);
            }
            else if(itemState == ItemState.InInventory)
            {
                // only sell item when this item's shop is open
                // and not when eg inventory is open, or another shop is open
                if(shopKeeper.shop.IsOpen)
                {
                    // Remove item from inventory
                    shopKeeper.shop.AddItem(this, ItemState.InShop);
                    shopKeeper.playerInventory.RemoveItem(this);
                    shopKeeper.playerInventory.AddMoney(price);
                }
                else
                {
                    // equip
                    equiomentChanger.Equip(itemScriptable.itemType, itemScriptable.label);
                    Debug.Log("You can only sell items when the item's shop is open");
                }
                
            }
            
        }

    }

    [System.Serializable]
    public enum ItemState
    {
        InShop,
        InCart,
        InInventory
    }
}
