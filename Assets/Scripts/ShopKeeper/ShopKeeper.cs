using UnityEngine;
using ShopSystem;
using System;
using UnityEngine.UI;

public class ShopKeeper : MonoBehaviour
{
    public Shop shop;
    public Inventory inventory;
    public Cart cart;
    public PlayerInvenotry playerInventory;

    // the message that pops up when the player interacts with the shopkeeper
    public Transform messagePopup;

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
            ShowPopup(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            ShowPopup(false);
            shop.OpenShop(false);
            inventory.OpenInventory(false);
            onShopClose?.Invoke(this, EventArgs.Empty);
        }
    }

    private void ShowPopup(bool flag)
    {
        messagePopup.gameObject.SetActive(flag);
    }

    private void OpenShop(Collider2D other)
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

    [SerializeField] private Button button;
    [SerializeField] private float offsetX;
    [SerializeField] private float offsetY;

    private RectTransform buttonRectTransform;

    void Start()
    {
        // Get the RectTransform component of the button:
        buttonRectTransform = button.GetComponent<RectTransform>();
    }

    void LateUpdate()
    {
        // Get the screen position of the game object:
        Vector3 screenPos = Camera.main.WorldToScreenPoint(transform.position);
        // Set the position of the button's RectTransform component:
        buttonRectTransform.position = new Vector3(screenPos.x + offsetX, screenPos.y + offsetY, 0);
    }
}
