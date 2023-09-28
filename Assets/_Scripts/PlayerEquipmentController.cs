using System;
using CharacterCreator2D;
using UnityEngine;

namespace _Scripts
{
    public class PlayerEquipmentController : MonoBehaviour
    {
        [SerializeField] private CharacterViewer character;
        private CharacterData _characterData;
        [SerializeField] private Animator animator;
        
        public Action<SlotCategory,Part> onEquipmentChanged;

        private void Awake()
        {
            _characterData = character.GenerateCharacterData();
            onEquipmentChanged += EquipItem;
        }

        public void RebakeCharacter()
        {
            //Equip and change your characters first
          //  character.EquipPart(SlotCategory.Armor, "Fantasy 00 Male");
           // character.SetPartColor(SlotCategory.Armor, ColorCode.Color3, color_3);

            //Rebake the character to apply the previous changes
            character.Bake();
        }
        
        public void EquipItem(SlotCategory slotCategory, Part itemName)
        {
            character.EquipPart(slotCategory, itemName);
            character.Bake();
        }

        public void EquipItemToQuickSlot()
        {
            Debug.Log("EquipItemToQuickSlot");
        }

    }
}