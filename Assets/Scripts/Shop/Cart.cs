using System.Collections.Generic;
using UnityEngine;

namespace ShopSystem
{
    public class Cart : MonoBehaviour
    {
        public List<Item> cartItems = new List<Item>();
        public Transform itemsContainer; // parent of the items


        private Shop shop;
        private Inventory inventory;

        private void Awake()
        {
            shop = FindObjectOfType<Shop>();
            inventory = FindObjectOfType<Inventory>();
        }
        /// <summary>
        /// Add an <see cref="Item"/> to the cart.
        /// </summary>
        public void AddItem(Item item, ItemState itemState)
        {
            if(item != null)
            {
                cartItems.Add(item);
                item.itemState = itemState;
                item.transform.SetParent(itemsContainer);
                Debug.Log(item.itemScriptable.itemName + " added to cart");
            }
                
            else
                Debug.LogError("Item is null and cannot be added to the cart");
        }

        /// <summary>
        /// Remove an <see cref="Item"/> from the cart.
        /// </summary>
        public void RemoveItem(Item item)
        {
            if(item != null)
            { 
                cartItems.Remove(item);
                Debug.Log(item.itemScriptable.itemName + " removed from cart");
            }
                
            else
                Debug.LogError("Item is null and cannot be removed from the cart");
        }


        public void BuyAllItems()
        {
            foreach (var item in cartItems)
            {
                inventory.AddItem(item, ItemState.InInventory);
            }
            cartItems.Clear();
        }


    }

}
