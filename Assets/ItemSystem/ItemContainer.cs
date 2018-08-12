using System;
using System.Linq;
using UnityEngine;

namespace ItemSystem
{
    public class ItemContainer : MonoBehaviour
    {
        public Item contained;
        public ItemDisplay display;
        public int tick = 1;
        public int every_ticks = 120;


        // Use this for initialization
        void Start()
        {
            if (contained != null)
            {
                // TODO randomly choose an item
            }
        }

        private void Update()
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
        }

        private void Awake()
        {
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

        private void OnMouseEnter()
        {
            if (display)
            {
                display.show(this.contained);
            }
        }

        private void OnMouseExit()
        {
            if (display)
            {
                display.hide();
            }
        }
    }
}