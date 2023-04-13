using System.Collections.Generic;
using UnityEngine;

namespace ShopSystem
{
    public class Inventory : MonoBehaviour
    {
        public List<Item> inventoryItems = new List<Item>();
        public Transform itemsContainer; // parent of the items

        /// <summary>
        /// Add an <see cref="Item"/> to the inventory.
        /// </summary>
        public void AddItem(Item item)
        {
            if(item != null)
            {
                inventoryItems.Add(item);
                item.itemState = ItemState.InInventory;
                item.transform.SetParent(itemsContainer);
                Debug.Log(item.itemScriptable.itemName + " added to the inventory");
            }
            else
                Debug.LogError("Item is null and cannot be added to the inventory");
        }

        /// <summary>
        /// Remove an <see cref="Item"/> from the inventory.
        /// </summary>
        public void RemoveItem(Item item)
        {
            if(item != null)
            { 
                inventoryItems.Remove(item);
                Debug.Log(item.itemScriptable.itemName + " removed from inventory");
            }
            else
                Debug.LogError("Item is null and cannot be removed from the inventory");
        }
    }
}
