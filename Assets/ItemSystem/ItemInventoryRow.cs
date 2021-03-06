﻿using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Experimental.PlayerLoop;
using UnityEngine.UI;

namespace ItemSystem
{
    public class ItemInventoryRow : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        public ItemDisplay display;
        public Text name_text;
        public Button activate_button;
        public float button_height = 15;
        public int tick = 1;
        public int every_ticks = 120;

        [SerializeField] private Item _item;
        public Player player;

        public Item item
        {
            get { return _item; }
            set
            {
                _item = value;
                update();
            }
        }

/*        void Update()
        {
            if (!display)
            {
                tick += 1;
                if (tick % every_ticks == 0)
                {
                    search_for_display();
                    tick = 1;
                }
            }
        }*/

        private void update()
        {
            if (item != null)
            {
                name_text.text = item.display_name;

                activate_button.gameObject.SetActive(item.activatable);
                if (!item.activatable)
                {
                    var rectTransform = GetComponent<RectTransform>();
                    rectTransform.sizeDelta =
                        new Vector2(rectTransform.sizeDelta.x, rectTransform.sizeDelta.y - button_height);
                }
            }
        }

        private void Awake()
        {
            update();
            search_for_display();
        }

        private void search_for_display()
        {
            var foundObjects = FindObjectsOfType<ItemDisplay>();
            if (foundObjects.Length == 1)
            {
                this.display = foundObjects.First();
            }
            else
            {
                Debug.Log("not the right number of CombatantDisplay's");
            }
        }


        public void OnPointerEnter(PointerEventData eventData)
        {
            display.show(item);
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            display.hide();
        }

        public void Thrash()
        {
            player.remove_item(_item);
        }

        public void Activate()
        {
        }
    }
}