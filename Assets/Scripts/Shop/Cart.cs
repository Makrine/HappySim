namespace ShopSystem
{
    public class Cart : Container
    {
        private Inventory inventory;

        private void Awake()
        {
            inventory = FindObjectOfType<Inventory>();
        }
        
        // called from a button
        public void BuyAllItems()
        {
            foreach (var item in Items)
            {
                inventory.AddItem(item, ItemState.InInventory);
            }
            Items.Clear();
        }

    }

}
