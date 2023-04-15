using UnityEngine;
using UnityEngine.U2D.Animation;
using ShopSystem;

/// <summary>
/// This class is used to swap the clothes of the player
/// </summary>
public class EquipmentChanger : MonoBehaviour
{
    // The renderers and resolvers for the different parts of the player
    public RendererResolver[] Top;
    public RendererResolver[] Bottom;
    public RendererResolver[] Shoes;
    public RendererResolver Glasses;

    public Equipment equipment;

    private void Awake()
    {
        equipment = GetComponentInParent<Equipment>();
    }

    /// <summary>
    /// Change the item of the player. Returns the current equipped item so it can be swapped
    /// </summary>
    public Item Equip(ItemType itemType, string label)
    {
        Item currentItem = null;

        // Find the item in the equipment that is of the same type as the item we want to equip
        foreach (var item in equipment.Items)
        {
            if (item.itemScriptable.itemType == itemType)
            {
                currentItem = item;
                break;
            }
        }

        switch (itemType)
        {
            case ItemType.Top:
                foreach (var item in Top)
                {
                    item.spriteResolver.SetCategoryAndLabel(item.spriteResolver.GetCategory(), label);
                }
                break;
            case ItemType.Bottom:
                foreach (var item in Bottom)
                {
                    item.spriteResolver.SetCategoryAndLabel(item.spriteResolver.GetCategory(), label);
                }
                break;
            case ItemType.Shoes:
                foreach (var item in Shoes)
                {
                    item.spriteResolver.SetCategoryAndLabel(item.spriteResolver.GetCategory(), label);
                }
                break;
            case ItemType.Glasses:
                Glasses.spriteResolver.SetCategoryAndLabel(Glasses.spriteResolver.GetCategory(), label);
                break;
            default:
                break;
        }
        return currentItem;
    }
}

[System.Serializable]
public class RendererResolver
{
    public ItemType itemType;
    public SpriteRenderer spriteRenderer;
    public SpriteResolver spriteResolver;
}


public static class Labels
{
    public static string bodyRed = "BodyRed";
    public static string bodyGreen = "BodyGreen";
    public static string TrousersBlue = "TrousersBlue";
    public static string TrousersYellow = "TrousersYellow";
    public static string FootBrown = "FootBrown";
    public static string FootGreen = "FootGreen";
    public static string GlassesN = "GlassesN";
    public static string glassesCool = "GlassesCool";
}