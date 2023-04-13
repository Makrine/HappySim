using UnityEngine;

namespace ShopSystem
{
    public class Inventory : MonoBehaviour
    {
        [HideInInspector]
        public CanvasGroup inventoryUI;
        public Transform itemsContainer;

        private void Awake()
        {
            inventoryUI = GetComponent<CanvasGroup>();
        }
        /// <summary>
        /// Open or close the inventory UI
        /// </summary>
         public void OpenInventory(bool flag)
         {
              inventoryUI.alpha = flag ? 1 : 0;
         }
    }
}
