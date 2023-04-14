using UnityEngine;
using ShopSystem;

public class PlayerInvenotry : Container
{
    public int money = 100;
    [HideInInspector]
    public Inventory inventory;
    
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
