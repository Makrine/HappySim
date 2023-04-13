using UnityEngine;

namespace ShopSystem
{
    public class Cart : Container
    {
        public TMPro.TMP_Text total_price_txt;
        public int total_price;

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
