using UnityEngine;
using ShopSystem;
using System;
using UnityEngine.UI;

/// <summary>
/// This class is used to control the shopkeeper of a shop
/// </summary>
public class ShopKeeper : MonoBehaviour
{
    // The shop and cart  of the shopkeeper
    public Shop shop;
    public Cart cart;

    public Inventory inventory;

    // the inventory of the player who enters the shop
    public PlayerInvenotry playerInventory;
    

    // the message that pops up when the player interacts with the shopkeeper
    public RectTransform messagePopup;
    // the offset of the message popup from the shopkeeper
    public Vector2 offset;

    public Button noBtn;
    public Button yesBtn;

    public UIManager uimanager = new();

    
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

    }

    // this is to make sure that the popup is always above the shopkeeper
    void LateUpdate()
    {
        // Get the screen position of the game object:
        Vector3 screenPos = Camera.main.WorldToScreenPoint(transform.position);
        // Set the position of the popup
        messagePopup.position = new Vector3(screenPos.x + offset.x, screenPos.y + offset.y, 0);
    }
}
