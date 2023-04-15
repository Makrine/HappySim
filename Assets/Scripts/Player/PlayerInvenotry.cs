using ShopSystem;
using UnityEngine.InputSystem;

/// <summary>
/// This class is used to store the items that the player has bought
/// as well as keep track of the money the player has and the methods to add and remove money
/// </summary>
public class PlayerInvenotry : Container
{
    public int money = 100;

    // references to the inventory and equipment of the player
    public Inventory inventory;
    public Equipment equipment;

    private void Awake()
    {
        inventory.UpdateMoney(money);
    }
    
    public void OpenInvetory(InputAction.CallbackContext obj)
    {
        if(inventory.IsOpen)
        {
            inventory.OpenInventory(false);
        }
            
        else
        {
            inventory.OpenInventory(true);
        }
    }

    /// <summary>
    /// Adds money to the player
    /// </summary>
    public void AddMoney(int amount)
    {
        money += amount;
        inventory.UpdateMoney(money);
    }

    /// <summary>
    /// Removes money from the player if he has enough
    /// </summary>
    public bool RemoveMoney(int amount)
    {
        if(money >= amount)
        {
            money -= amount;
            inventory.UpdateMoney(money);
            return true;
        }
        return false;
    }

}
