using UnityEngine;
using ShopSystem;

public class ShopKeeper : MonoBehaviour
{
    public Shop shop;
    public Inventory inventory;
    public Cart cart;
    public PlayerInvenotry playerInventory;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            // Get the inventory of the player who entered the shop
            playerInventory = other.GetComponent<PlayerInvenotry>();
            // Set the items container of the player inventory to the items container of the shop inventory
            // This way the inventory UI will show the items of the player
            playerInventory.itemsContainer = inventory.itemsContainer;
            shop.OpenShop(true);
            inventory.OpenInventory(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            shop.OpenShop(false);
            inventory.OpenInventory(false);
        }
    }
}
