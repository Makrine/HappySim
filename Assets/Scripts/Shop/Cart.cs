namespace ShopSystem
{
    public class Cart : Container
    {

        private Shop shop;
        private Inventory inventory;

        private void Awake()
        {
            inventory = FindObjectOfType<Inventory>();
            shop = FindObjectOfType<Shop>();
        }
        /// <summary>
        /// Add an <see cref="Item"/> to the cart.
        /// </summary>
        public override void AddItem(Item item)
        {
           base.AddItem(item);
           if(item != null)
            item.itemState = ItemState.InCart;
        }

        public void BuyAllItems()
        {
            foreach (var item in Items)
            {
                inventory.AddItem(item);
            }
            Items.Clear();
        }

    }

}
