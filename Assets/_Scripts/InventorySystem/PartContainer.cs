using System;
using System.Collections.Generic;
using CharacterCreator2D;
using Enca.Extensions;
using UnityEngine;

namespace _Scripts.InventorySystem
{
    [CreateAssetMenu]
    public class PartContainer : ScriptableObject
    {
        //Todo add female armor and pants.
        //Todo add random colors inside chars.
        public List<Part> armorPart;
        public List<Part> bootsPart;
        public List<Part> glovesPart;
        public List<Part> helmetPart;
        public List<Part> weaponPart;
        public List<Part> shieldPart;
        public List<Part> pantsPart;

        public Part GetRandomItemByType(ItemType itemType)
        {
            return itemType switch
            {
                ItemType.Armor => armorPart.SelectRandomItem(),
                ItemType.Boots => bootsPart.SelectRandomItem(),
                ItemType.Gloves => glovesPart.SelectRandomItem(),
                ItemType.Helmet => helmetPart.SelectRandomItem(),
                ItemType.Weapon => weaponPart.SelectRandomItem(),
                ItemType.Shield => shieldPart.SelectRandomItem(),
                ItemType.Pants => pantsPart.SelectRandomItem(),
                _ => throw new ArgumentOutOfRangeException(nameof(itemType), itemType, null)
            };
        }

        public Part GetRandomItem()
        {
            var allItems = Extensions.MergeLists(armorPart, bootsPart, glovesPart, helmetPart, weaponPart, shieldPart,
                pantsPart);
            return allItems.SelectRandomItem();
        }
    }

    public enum ItemType
    {
        Armor,
        Boots,
        Gloves,
        Helmet,
        Weapon,
        Shield,
        Pants
    }
}