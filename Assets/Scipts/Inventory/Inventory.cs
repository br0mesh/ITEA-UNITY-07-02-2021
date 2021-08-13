using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scipts.Inventory
{
    public class Inventory : MonoBehaviour
    {
        private ItemDatabase database;

       // public List<Item> items = new List<Item>();
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
                items.Add(new Item());
                slots.Add(Instantiate(inventorySlot, slotPanel.transform).GetComponent<InventorySlot>());
                slots[i].ID = i;
            }

            AddItem(0, 1);
            AddItem(1, 1);
            AddItem(0, 1);
        }
       // public ItemUIView GetIte
        public bool AddItem(int id, int amount)
        {
            Item itemToAdd = database.FletchItemByID(id);
            itemToAdd.Amount = amount;

            if (itemToAdd.ID == -1) return false;

            if (itemToAdd.Stackable)
            {
                InventorySlot slot = IsInInventory(itemToAdd.ID);
                if (slot != null)
                {
                    ItemUIView itemData = slot.transform.GetChild(0).GetComponent<ItemUIView>();

                    if(itemData.Item.Amount + itemToAdd.Amount > itemData.Item.MaxStack)
                    {
                        int overMaxStackAmount = (itemData.Item.Amount + itemToAdd.Amount) - itemData.Item.MaxStack;
                        itemToAdd.Amount -= overMaxStackAmount;
                        itemData.Item.Amount = itemData.Item.MaxStack;
                        CreateItem(itemToAdd);
                    }
                    else
                    {
                        itemData.Item.Amount += amount;
                        itemData.UpdateUI();
                    }
                }
            }

            return CreateItem(itemToAdd);
        }
        private bool CreateItem(Item item)
        {
            for (int i = 0; i < items.Count; i++)
            {
                if (items[i].ID == -1)
                {
                    items[i] = item;
                    GameObject itemObj = Instantiate(inventoryItem, slots[i].transform);

                    ItemUIView itemUIView = itemObj.GetComponent<ItemUIView>();

                    itemUIView.Init(items[i]);
                    itemUIView.SetSlot(slots[i]);

                    return true;
                }
            }
            return false;
        }
        private InventorySlot IsInInventory(int id)
        {
            for (int i = 0; i < items.Count; i++)
            {
                if (items[i].ID == id)
                    return slots[i];
            }
            return null;
        }
    }
}
