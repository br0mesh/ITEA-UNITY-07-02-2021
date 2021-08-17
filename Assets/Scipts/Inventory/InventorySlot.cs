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

        public void SetItemUIView(ItemUIView itemUIView)
        {
            this.itemUIView = itemUIView;
            this.itemUIView.OnItemStartDrag += ItemGraged;
        }

        private void ItemGraged()
        {
            itemUIView.OnItemStartDrag -= ItemGraged;
            itemUIView = null;
        }

        public void OnDrop(PointerEventData eventData)
        {
            ItemUIView droppedItem = eventData.pointerDrag.GetComponent<ItemUIView>();
            if (itemUIView == null)
            {
                itemUIView = droppedItem;
                itemUIView.SetSlot(this);
            }
            else if(itemUIView.Item.ID != droppedItem.Item.ID)
            {
                itemUIView.SetSlot(droppedItem.Slot);

                itemUIView = droppedItem;
                itemUIView.SetSlot(this);
            }
        }
    }
}
