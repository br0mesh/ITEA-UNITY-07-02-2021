using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Assets.Scipts.Inventory
{
    public class InventorySlot : MonoBehaviour, IDropHandler
    {
        private ItemUIView itemUIView;
        public ItemUIView ItemUIView
        {
            get => itemUIView;
        }

        private int id;
        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        public void SetItem(Item item)
        {
            itemUIView.Init(item);
            itemUIView.OnItemStartDrag += ItemGraged;
        }

        private void ItemGraged()
        {
            itemUIView.OnItemStartDrag -= ItemGraged;
            itemUIView = null;
        }

        public void OnDrop(PointerEventData eventData)
        {
            ItemUIView droppedItem = eventData.pointerDrag.GetComponent<ItemUIView>();
            if (itemUIView == null) //if (inventory.items[id].ID == -1)
            {
                //droppedItem.s
                //!!!!! //inventory.items[droppedItem.Slot] = new Item(-1, "null", "null", false, 0);
                itemUIView = droppedItem;
                itemUIView.SetSlot(this);
                //droppedItem.Slot = id;
                //droppedItem.SetSlot(transform);
                //inventory.items[droppedItem.Slot] = droppedItem.Item;
            }
            //else if (itemUIView.Item.ID == droppedItem.Item.ID) //else if (inventory.items[id].ID == droppedItem.Item.ID)
            //{
            //    //TODO Stack items
            //}
            else if(itemUIView.Item.ID != droppedItem.Item.ID)//else if (inventory.items[id].ID != -1)
            {
                itemUIView.SetSlot(droppedItem.Slot);

                itemUIView = droppedItem;
                itemUIView.SetSlot(this);

                
                //Transform itemToSwap = transform.GetChild(0);
                //ItemUIView itemData = itemToSwap.gameObject.GetComponent<ItemUIView>();
                //inventory.items[droppedItem.Slot] = itemData.Item;
                //itemData.Slot = droppedItem.Slot;
                //itemData.SetSlot(inventory.slots[droppedItem.Slot].transform);
                //droppedItem.Slot = id;
                //droppedItem.SetSlot(inventory.slots[id].transform);
                //inventory.items[droppedItem.Slot] = droppedItem.Item;
            }
        }
    }
}
