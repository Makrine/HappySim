namespace ShopSystem
{
    public class Cart : Container
    {

        private Shop shop;

        private void Awake()
        {
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

    }

}
