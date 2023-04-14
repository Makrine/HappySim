using UnityEngine;
using ShopSystem;
using System;
using UnityEngine.UI;

public class ShopKeeper : MonoBehaviour
{
    // The shop, cart and inventory of the shopkeeper
    public Shop shop;
    public Inventory inventory;
    public Cart cart;

    // the inventory of the player who enters the shop
    public PlayerInvenotry playerInventory;
    

    // the message that pops up when the player interacts with the shopkeeper
    public RectTransform messagePopup;
    // the offset of the message popup from the shopkeeper
    public Vector2 offset;

    public Button noBtn;
    public Button yesBtn;

    public UIManager uimanager = new();

    // Events that are invoked when the shop is opened or closed
    public EventHandler onShopOpen;
    public EventHandler onShopClose;
    
    private void Awake()
    {
        shop.shopKeeper = this;
        cart.shopKeeper = this;

        noBtn.onClick.AddListener(() => ShowPopup(false));
        yesBtn.onClick.AddListener(() => OpenShop(true));
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
            // playerInventory.itemsContainer = inventory.itemsContainer;
            // playerInventory.inventory = inventory;
            // playerInventory.equipment.itemsContainer = inventory.equippedContainer;
            inventory.UpdateMoney(playerInventory.money);
            ShowPopup(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            ShowPopup(false);

            if(shop.IsOpen)
                OpenShop(false);
        }
    }

    private void ShowPopup(bool flag)
    {
        if(flag) uimanager.FadeInPopup();
        else uimanager.FadeOutPopup();
    }

    private void OpenShop(bool flag)
    {
        ShowPopup(false);

        shop.OpenShop(flag);

        //inventory.OpenInventory(flag);
        if(flag)
            onShopOpen?.Invoke(this, EventArgs.Empty);
        else
            onShopClose?.Invoke(this, EventArgs.Empty);

    }

    void LateUpdate()
    {
        // Get the screen position of the game object:
        Vector3 screenPos = Camera.main.WorldToScreenPoint(transform.position);
        // Set the position of the popup
        messagePopup.position = new Vector3(screenPos.x + offset.x, screenPos.y + offset.y, 0);
    }
}
