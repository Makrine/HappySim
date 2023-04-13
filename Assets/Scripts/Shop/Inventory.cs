namespace ShopSystem
{
    public class Inventory : Container
    {

        /// <summary>
        /// Add an <see cref="Item"/> to the inventory.
        /// </summary>
        public override void AddItem(Item item)
        {
            base.AddItem(item);
            if(item != null)
                item.itemState = ItemState.InInventory;

        }
    }
}
