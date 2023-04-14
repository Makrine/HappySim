using UnityEngine;

namespace ShopSystem
{

    [CreateAssetMenu(fileName = "New Item", menuName = "Item")]
    public class ItemScriptable : ScriptableObject
    {
        public ItemType itemType;
        public string itemName;
        public int price;
        public Sprite itemSprite;
        public Sprite itemSpriteUI;
        public string label;

        
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