using System;
using UnityEngine;
using System.Collections.Generic;

namespace ShopSystem
{
    /// <summary>
    /// This is a parent class for the <see cref="Cart"/>, <see cref="Shop"/> and <see cref="PlayerInvenotry"/> classes.
    /// It contains the methods to add and remove items in the corresponding containers.
    /// It also contains the events for when an item is added or removed.
    /// </summary>
    public class Container : MonoBehaviour
    {
        // Events for when an item is added or removed
        public EventHandler<ItemAddedEventArgs> onItemAdded;
        public EventHandler<ItemAddedEventArgs> onItemRemoved;

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
                // Invoke the onItemAdded event
                onItemAdded?.Invoke(this, new ItemAddedEventArgs(item, true));
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
                // Invoke the onItemRemoved event
                onItemRemoved?.Invoke(this, new ItemAddedEventArgs(item, false));
            }
            else
                Debug.LogError("Item is null and cannot be removed");
        }
    }
    /// <summary>
    /// Event arguments for the <see cref="onItemAdded"/> and <see cref="onItemRemoved"/> events.
    /// </summary>
    public class ItemAddedEventArgs : EventArgs
    {
        public Item item { get; }
        public bool isAdded { get; }

        public ItemAddedEventArgs(Item item, bool isAdded)
        {
            this.item = item;
            this.isAdded = isAdded;
        }
    }

}