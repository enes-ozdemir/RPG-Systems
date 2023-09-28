using System;
using UnityEngine;

namespace _Scripts.InventorySystem.QuickSlot
{
    public class QuickSlotPanel : MonoBehaviour
    {
        [SerializeField] private Transform quickSlotParent;
        [SerializeField] private QuickSlot[] quickSlots;

        public event Action<BaseItemSlot> OnPointerEnterEvent;
        public event Action<BaseItemSlot> OnPointerExitEvent;
        public event Action<BaseItemSlot> OnRightClickEvent;
        public event Action<BaseItemSlot> OnBeginDragEvent;
        public event Action<BaseItemSlot> OnEndDragEvent;
        public event Action<BaseItemSlot> OnDragEvent;
        public event Action<BaseItemSlot> OnDropEvent;
        public event Action<BaseItemSlot> OnShiftRightClickEvent;

        private void Awake()
        {
            DontDestroyOnLoad(this);
        }

        private void Start()
        {
            for (int i = 0; i < quickSlots.Length; i++)
            {
                quickSlots[i].OnClickEvent += OnRightClickEvent;
                quickSlots[i].OnPointerEnterEvent += OnPointerEnterEvent;
                quickSlots[i].OnPointerExitEvent += OnPointerExitEvent;
                quickSlots[i].OnBeginDragEvent += OnBeginDragEvent;
                quickSlots[i].OnEndDragEvent += OnEndDragEvent;
                quickSlots[i].OnDropEvent += OnDropEvent;
                quickSlots[i].OnDragEvent += OnDragEvent;
                quickSlots[i].OnShiftRightClickEvent += OnShiftRightClickEvent;
            }

            // SelectSlot();
        }

        private void OnValidate()
        {
            quickSlots = quickSlotParent.GetComponentsInChildren<QuickSlot>();
        }

        private void SelectSlot()
        {
       
        }

        public bool AddItem(Item item, out Item previousItem)
        {
            for (int i = 0; i < quickSlots.Length; i++)
            {
                if (true)
                {
                    previousItem = quickSlots[i].Item;
                    quickSlots[i].Item = item;
                    //_quickSlots[i].Amount = _quickSlots[i].Amount;
                    return true;
                }
            }

            previousItem = null;
            return false;
        }

        /**
     * Remove Item from the slot
    */
        public bool RemoveItem(Item item)
        {
            for (int i = 0; i < quickSlots.Length; i++)
            {
                if (quickSlots[i].Item == item)
                {
                    if (quickSlots[i].Amount > 0)
                    {
                        quickSlots[i].Amount--;
                        if (quickSlots[i].Amount == 0)
                        {
                            quickSlots[i].Item = null;
                            //playerManager.currentItem = null;
                        }
                    }
                    else
                    {
                        quickSlots[i].Item = null;
                    }

                    return true;
                }
            }

            return false;
        }
    }
}