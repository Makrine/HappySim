using UnityEngine;

namespace ShopSystem
{
    /// <summary>
    /// This class handles the items that are in the cart
    /// </summary>
    public class Cart : Container
    {
        public TMPro.TMP_Text total_price_txt;
        public int total_price;

        [HideInInspector]
        public ShopKeeper shopKeeper;

        private void Awake()
        {
            // Set the total price to 0 at the start
            total_price_txt.text = total_price.ToString();
            // Add listeners to the onItemAdded event and onItemRemoved event
            onItemAdded += UpdateTotalPrice;
            onItemRemoved += UpdateTotalPrice;
        }

        /// <summary>
        /// Override the AddItem method to limit the number of items in the cart to 3
        /// </summary>
        public override bool AddItem(Item item, ItemState itemState)
        {
            if(Items.Count == 3)
            {
                Debug.Log("Cart is full");
                return false;
            }
            base.AddItem(item, itemState);
            return true;
        }
        
        /// <summary>
        /// Updates the total price of the cart when an item is added
        /// </summary>
        private void UpdateTotalPrice(object sender, ItemAddedEventArgs e)
        {
            if(e.isAdded)
            {
                total_price += e.item.price;
            }
            else
            {
                total_price -= e.item.price;
            }
            total_price_txt.text = total_price.ToString();
        }

        // called from a button
        public void BuyAllItems()
        {
            if(shopKeeper.playerInventory.RemoveMoney(total_price))
            {
                foreach (var item in Items)
                {
                    shopKeeper.playerInventory.AddItem(item, ItemState.InInventory);
                    onItemRemoved?.Invoke(this, new ItemAddedEventArgs(item, false));
                    item.equiomentChanger = shopKeeper.playerInventory.GetComponentInChildren<EquipmentChanger>();
                }
                Items.Clear();
            }
            else
            {
                Debug.Log("Not enough money :(");
            }
            
        }

    }

}
