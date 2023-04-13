using UnityEngine;
using UnityEngine.UI;

namespace ShopSystem
{
    public class Item : MonoBehaviour
    {
        public ItemScriptable itemScriptable;
        public ItemState itemState; // The state of the item

        // Reference to the shop
        private Shop shop;
        private Cart cart;
        private Inventory inventory;
        private Button btn;

        private void Awake()
        {
            // Get the shop reference
            shop = FindObjectOfType<Shop>();
            cart = FindObjectOfType<Cart>();
            inventory = FindObjectOfType<Inventory>();
            // Get the button component
            btn = GetComponent<Button>();
            // Add a listener to the button click event
            btn.onClick.AddListener(HandleItemClick);
        }

        /// <summary>
        /// Handle the click event of the item
        /// If the item is in shop, it addes it to the cart
        /// If the item is in cart, it removes it from the cart or adds it to the inventory
        /// If the item is in inventory, it removes it sells it
        /// </summary>
        private void HandleItemClick()
        {
            if(itemState == ItemState.InShop)
            {
                // Add item to cart
                cart.AddItem(this, ItemState.InCart);
                shop.RemoveItem(this);
            }
            else if(itemState == ItemState.InCart)
            {
                shop.AddItem(this, ItemState.InShop);
                // Remove item from cart
                cart.RemoveItem(this);
            }
            else if(itemState == ItemState.InInventory)
            {
                // Remove item from inventory
                shop.AddItem(this, ItemState.InShop);
                inventory.RemoveItem(this);
                Debug.Log(itemScriptable.itemName + " sold");
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
