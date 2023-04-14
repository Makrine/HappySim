using UnityEngine;
using UnityEngine.Events;

namespace ShopSystem
{
    public class Inventory : MonoBehaviour
    {
        [HideInInspector]
        public CanvasGroup inventoryUI;
        public Transform itemsContainer;
        public Transform equippedContainer;
        public TMPro.TMP_Text moneyTxt;
        public UIManager uimanager = new();

        public bool IsOpen => inventoryUI.interactable;

        private void Awake()
        {
            inventoryUI = GetComponent<CanvasGroup>();
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
