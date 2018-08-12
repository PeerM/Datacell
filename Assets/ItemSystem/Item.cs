using System;
using combat;
using UnityEngine;

namespace ItemSystem
{
    [CreateAssetMenu(fileName = "Item", menuName = "Inventory/Item")]
    public class Item : ScriptableObject
    {
        public string display_name;
        public int max_hp = 0;
        public bool activatable = false;
        public int attack_power = 0;
        public string attack_element = "normal"; // TODO implement element into combat
        public int armor;
        public float magic_barier;

        public void apply_to_stats(Stats stats)
        {
            stats.max_hp += max_hp;
            stats.attack_power += attack_power;
            stats.armor += armor;
            stats.magic_barier += magic_barier;
        }

        private void OnEnable()
        {
            if (display_name == "")
            {
                display_name = name;
            }
        }

        public override string ToString()
        {
            var accu = display_name + "\n";
            if (max_hp != 0)
            {
                accu += max_hp + " max hp\n";
            }

            if (attack_power != 0)
            {
                accu += attack_power + " " + attack_element + " damage\n";
            }

            if (armor != 0)
            {
                accu += armor + " armor\n";
            }

            if (magic_barier != 0)
            {
                accu += String.Format("{0:0.#\\%}", magic_barier * 100) + " magic barrier\n";
            }

            return accu;
        }
    }
}