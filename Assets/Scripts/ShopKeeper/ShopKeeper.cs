using UnityEngine;
using ShopSystem;
using System;

public class ShopKeeper : MonoBehaviour
{
    public Shop shop;
    public Inventory inventory;
    public Cart cart;
    public PlayerInvenotry playerInventory;

    public EventHandler onShopOpen;
    public EventHandler onShopClose;
    
    private void Awake()
    {
        shop.shopKeeper = this;
        cart.shopKeeper = this;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            // Get the inventory of the player who entered the shop
            // using this, we will be able to sell items to the player
            // who enters the shop
            playerInventory = other.GetComponent<PlayerInvenotry>();
            // Set the items container of the player inventory to the items container of the shop inventory
            // This way the inventory UI will show the items of the player
            playerInventory.itemsContainer = inventory.itemsContainer;
            shop.OpenShop(true);
            inventory.OpenInventory(true);
            onShopOpen?.Invoke(this, EventArgs.Empty);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            shop.OpenShop(false);
            inventory.OpenInventory(false);
            onShopClose?.Invoke(this, EventArgs.Empty);
        }
    }
}
