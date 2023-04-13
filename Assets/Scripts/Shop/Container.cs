using UnityEngine;
using System.Collections.Generic;

namespace ShopSystem
{
    public class Container : MonoBehaviour
    {
         public List<Item> Items = new List<Item>();
        public Transform itemsContainer; // parent of the items

        /// <summary>
        /// Add an <see cref="Item"/> to the inventory.
        /// </summary>
        public virtual void AddItem(Item item, ItemState itemState)
        {
            if(item != null)
            {
                Items.Add(item);
                item.itemState = itemState;
                item.transform.SetParent(itemsContainer);
            }
            else
                Debug.LogError("Item is null and cannot be added");
        }

        /// <summary>
        /// Remove an <see cref="Item"/>.
        /// </summary>
        public virtual void RemoveItem(Item item)
        {
            if(item != null)
            { 
                Items.Remove(item);
            }
            else
                Debug.LogError("Item is null and cannot be removed");
        }
    }
}