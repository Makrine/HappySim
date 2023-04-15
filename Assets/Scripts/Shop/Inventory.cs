using UnityEngine;
using UnityEngine.UI;

namespace ShopSystem
{
    /// <summary>
    /// This is the UI represation of the <see cref="PlayerInvenotry"/> class.
    /// </summary>
    
    public class Inventory : MonoBehaviour
    {
        [HideInInspector]
        public CanvasGroup inventoryUI;
        public Transform itemsContainer;
        public Transform equippedContainer;
        public TMPro.TMP_Text moneyTxt;
        public DoTweensManager uimanager = new();
        public Button close;

        public bool IsOpen => inventoryUI.interactable;

        private void Awake()
        {
            inventoryUI = GetComponent<CanvasGroup>();
            close.onClick.AddListener(() => OpenInventory(false));
        }
        /// <summary>
        /// Open or close the inventory UI
        /// </summary>
         public void OpenInventory(bool flag)
         {
            if(flag)
                uimanager.FadeInPanel();
            else
                uimanager.FadeOutPanel();
              inventoryUI.interactable = flag;
              inventoryUI.blocksRaycasts = flag;
         }

        /// <summary>
        /// Update the money text
        /// </summary>
        public void UpdateMoney(int money)
        {
            moneyTxt.text = money.ToString();
        }
    }
}
