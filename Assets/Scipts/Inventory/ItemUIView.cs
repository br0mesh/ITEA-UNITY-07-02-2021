using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

namespace Assets.Scipts.Inventory
{
    public class ItemUIView : MonoBehaviour, IPointerDownHandler, IDragHandler, IEndDragHandler
    {
        [SerializeField] private Image itemImage;
        [SerializeField] private Text AmountText;
        [SerializeField] private CanvasGroup canvasGroup;

        private Item item;
        public Item Item
        {
            get
            { return item; }
            set
            {
                item = value;
                gameObject.name = item.Title;
                Debug.Log(item.Title);
            }
        }

        private InventorySlot slot;
        public InventorySlot Slot
        {
            get => slot;
        }

        public void Init(Item item)
        {
            this.item = item;
            UpdateUI();
        }
        public void UpdateUI()
        {
            itemImage.sprite = item.Sprite;
            AmountText.text = item.Amount.ToString();
        }
        public void SetSlot(InventorySlot slot)
        {
            this.slot = slot;
            transform.SetParent(slot.transform);
            transform.position = slot.transform.position;
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            Debug.Log(item.Title);
            canvasGroup.blocksRaycasts = true;
        }

        public void OnDrag(PointerEventData eventData)
        {
            if (item != null)
            {
                transform.position = eventData.position;
            }
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            if (item != null)
            {
                OnItemStartDrag?.Invoke();
                transform.SetParent(transform.parent.parent);
                transform.position = eventData.position;
                canvasGroup.blocksRaycasts = false;
            }
        }

        public Action OnItemStartDrag;
        public Action OnItemEndDrag;
    }
}
