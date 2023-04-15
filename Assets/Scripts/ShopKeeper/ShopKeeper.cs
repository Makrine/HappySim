using UnityEngine;
using ShopSystem;
using System;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Collections;

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
    public TMPro.TMP_Text label;
    public Transform bubbleSpeech;
    // the offset of the message popup from the shopkeeper
    public Vector2 offset;
    public Vector2 labelOffset;
    public Vector2 bubbleSpeechOffset;

    public Button noBtn;
    public Button yesBtn;

    public DoTweensManager shopDotweens = new();
    public DoTweensManager bubbleSpeechDoTween = new();
    
    private string shopName = "Gucci";

    // when the player doesn't have enough money, the speech bubble will say accordingly. This event is for this
    public EventHandler OnNotEnoughMoney; 
    // when the player has enough money, the speech bubble will say accordingly
    public EventHandler OnEnoughMoney; 
    public EventHandler OnItemNotBought; // when the player tries to sell an item that doesnt belong to the shopkeeper originally
    public EventHandler OnItemBought; // when the player sells an item to the shopkeeper

    private void Awake()
    {
        shop.shopKeeper = this;
        cart.shopKeeper = this;

        noBtn.onClick.AddListener(() => ShowPopup(false));
        yesBtn.onClick.AddListener(() => OpenShop(true));

        OnNotEnoughMoney += NotEnoughMoney;
        OnEnoughMoney += EnoughMoney;
        OnItemNotBought += ItemNotBought;
        OnItemBought += ItemBought;

        if(!label.text.Contains("Gucci"))
            shopName = "Makrina";
        else
            shopName = "Gucci";
    }

    private void ChangeSpeechBubbleText(string text)
    {
        bubbleSpeech.GetComponentInChildren<TMPro.TMP_Text>().text = text;
    }
    private void ItemNotBought(object sender, EventArgs e)
    {
        ChangeSpeechBubbleText("Sorry! Find the right shopkeeper!");
    }

    private void ItemBought(object sender, EventArgs e)
    {
        ChangeSpeechBubbleText("Thanks for the item!");
    }

    private void EnoughMoney(object sender, EventArgs e)
    {
        ChangeSpeechBubbleText("Thank you! Come again!");
    }

    private void NotEnoughMoney(object sender, EventArgs e)
    {
        ChangeSpeechBubbleText("Sorry! You don't have enough money!");
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            AudioManager.Instance.PlayAudio(AudioManager.Instance.popup);
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
            AudioManager.Instance.PlayAudio(AudioManager.Instance.popupClose);
            ShowPopup(false);

            if(shop.IsOpen)
                OpenShop(false);
        }
    }

    private void ShowPopup(bool flag)
    {
        if(flag) 
        {
            shopDotweens.FadeInPopup();
            if(shop.Items.Count == 0)
                messagePopup.GetComponentInChildren<TMPro.TMP_Text>().text = "Unfortunatly, I don't have any more items to sell. But you can sell me some!";
            else
                messagePopup.GetComponentInChildren<TMPro.TMP_Text>().text = String.Format("Hello! Would you like to buy or sell some cool items from {0}?", shopName);
        }
        else shopDotweens.FadeOutPopup();
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
        label.transform.position = new Vector3(screenPos.x + labelOffset.x, screenPos.y + labelOffset.y, 0);
        bubbleSpeech.position = new Vector3(screenPos.x + bubbleSpeechOffset.x, screenPos.y + bubbleSpeechOffset.y, 0);
    }

    /// <summary>
    /// This is called when a player buys an item so the shopkeeper says something
    /// </summary>
    public IEnumerator BubbleSpeech()
    {
        bubbleSpeechDoTween.FadeInPopup();
        yield return new WaitForSeconds(2f);
        bubbleSpeechDoTween.FadeOutPopup();
    }
}
