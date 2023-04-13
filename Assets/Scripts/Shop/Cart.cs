using System.Collections.Generic;
using UnityEngine;

namespace ShopSystem
{
    public class Cart : MonoBehaviour
    {
        public List<Item> cartItems = new List<Item>();

        /// <summary>
        /// Add an <see cref="Item"/> to the cart.
        /// </summary>
        public void AddItem(Item item)
        {
            if(item != null)
            {
                cartItems.Add(item);
                item.itemState = ItemState.InCart;
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
            if(item != null && cartItems.Remove(item))
            { 
                Debug.Log(item.itemScriptable.itemName + " removed from cart");
            }
                
            else
                Debug.LogError("Item is null and cannot be removed from the cart");
        }


    }

}
