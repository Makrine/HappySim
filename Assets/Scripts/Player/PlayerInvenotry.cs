using UnityEngine;
using ShopSystem;

public class PlayerInvenotry : Container
{
    public int money = 100;
    
    /// <summary>
    /// Adds money to the player
    /// </summary>
    public void AddMoney(int amount)
    {
        money += amount;
    }

    /// <summary>
    /// Removes money from the player if he has enough
    /// </summary>
    public bool RemoveMoney(int amount)
    {
        if(money >= amount)
        {
            money -= amount;
            return true;
        }
        return false;
    }

}
