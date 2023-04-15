using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Button inventoryBtn;

    private ShopSystem.Inventory inventory;

    private void Awake()
    {
        inventory = FindObjectOfType<ShopSystem.Inventory>();

        inventoryBtn.onClick.AddListener(OpenInventory);
    }

    private void OpenInventory()
    {
        inventory.OpenInventory(true);
    }
}