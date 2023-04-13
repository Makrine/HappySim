using System.Collections.Generic;
using UnityEngine;

namespace ShopSystem
{
    public class Container : MonoBehaviour
    {
        public List<Item> Items = new List<Item>();
        public Transform itemsContainer; // parent of the items

        /// <summary>
        /// Add an <see cref="Item"/>.
        /// </summary>
        public virtual void AddItem(Item item)
        {
            if(item != null)
            {
                Items.Add(item);
                //item.itemState = ItemState.InCart;
                item.transform.SetParent(itemsContainer);
                Debug.Log(item.itemScriptable.itemName + " added");
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
                Debug.Log(item.itemScriptable.itemName + " removed");
            }
                
            else
                Debug.LogError("Item is null and cannot be removedt");
        }
    }
}