using UnityEngine;

namespace ShopSystem
{

    [CreateAssetMenu(fileName = "New Item", menuName = "Item")]
    public class ItemScriptable : ScriptableObject
    {
        public ItemType itemType;
        public string itemName;
        public int price;
        public Sprite itemSpriteUI;
        public string label;
        public string shopKeeperTag;
        
    }

    [System.Serializable]
        public enum ItemType
        {
            Hat,
            Top,
            Bottom,
            Shoes,
            Glasses
        }
}