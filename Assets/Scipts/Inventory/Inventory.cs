using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scipts.Inventory
{
    public class Inventory : MonoBehaviour
    {
        private ItemDatabase database;

        public List<InventorySlot> slots = new List<InventorySlot>();

        [SerializeField]
        private GameObject inventoryPanel;
        [SerializeField]
        private GameObject slotPanel;
        [SerializeField]
        private GameObject inventorySlot;
        [SerializeField]
        private GameObject inventoryItem;
        [SerializeField]
        private int slotAmount;
        void Start()
        {
            database = GetComponent<ItemDatabase>();

            for (int i = 0; i < slotAmount; i++)
            {
                slots.Add(Instantiate(inventorySlot, slotPanel.transform).GetComponent<InventorySlot>());
            }

            Item itemToAdd = database.FletchItemByID(0);
            itemToAdd.Amount = 1;
            AddItem(itemToAdd);
            itemToAdd.ID = 0;
            AddItem(itemToAdd);
            itemToAdd.ID = 1;
            AddItem(itemToAdd);
        }
        public bool HasFreeSpace()
        {
            return true;
        }
        public ItemUIView AddItem(Item itemToAdd)
        {
            if (itemToAdd.Stackable)
            {
                ItemUIView itemUIView = IsInInventory(itemToAdd.ID);
                if (itemUIView != null)
                {
                    if (itemUIView.Item.Amount + itemToAdd.Amount > itemUIView.Item.MaxStack)
                    {
                        int overMaxStackAmount = (itemUIView.Item.Amount + itemToAdd.Amount) - itemUIView.Item.MaxStack;
                        itemToAdd.Amount -= overMaxStackAmount;
                        itemUIView.Item.Amount = itemUIView.Item.MaxStack;
                        CreateItem(itemToAdd);
                    }
                    else
                    {
                        itemUIView.Item.Amount += itemToAdd.Amount;
                        itemUIView.UpdateUI();
                    }
                    return itemUIView;
                }
            }

            return CreateItem(itemToAdd);
        }
        private ItemUIView CreateItem(Item item)
        {
            for (int i = 0; i < slots.Count; i++)
            {
                if (slots[i].ItemUIView == null)
                {
                    GameObject itemObj = Instantiate(inventoryItem, slots[i].transform);

                    ItemUIView itemUIView = itemObj.GetComponent<ItemUIView>();

                    itemUIView.Init(item);
                    itemUIView.SetSlot(slots[i]);

                    slots[i].SetItemUIView(itemUIView);

                    return itemUIView;
                }
            }
            return null;
        }
        private ItemUIView IsInInventory(int id)
        {
            for (int i = 0; i < slots.Count; i++)
            {
                if (slots[i].ItemUIView == null)
                {
                    continue;
                }

                if (slots[i].ItemUIView.Item.ID == id)
                {
                    return slots[i].ItemUIView;
                }
            }

            return null;
        }
    }
}
