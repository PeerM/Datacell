using System.Collections.Generic;
using UnityEngine;

namespace ItemSystem
{
    public class PlayerInventory : MonoBehaviour
    {
        public GameObject itempanel_prefab;
        public GameObject gui_container;


        public void reload(List<Item> items, Player player)
        {
            // delete all childeren
            foreach (Transform child in gui_container.transform)
            {
                GameObject.Destroy(child.gameObject);
            }

            // and redo them
            foreach (var item in items)
            {
                var item_row = GameObject.Instantiate(itempanel_prefab, gui_container.transform);
                var itemInventoryRow = item_row.GetComponent<ItemInventoryRow>();
                itemInventoryRow.item = item;
                itemInventoryRow.player = player;
            }
        }
    }
}