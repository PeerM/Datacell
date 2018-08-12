using System;
using UnityEngine;

namespace combat
{
    [Serializable]
    public class Stats
    {
        public int max_hp = 0;
        public int attack_power = 0;
        public int armor;
        public float magic_barier;

        public Stats clone()
        {
            var tmp = new Stats();
            tmp.max_hp = max_hp;
            tmp.attack_power = attack_power;
            tmp.armor = armor;
            tmp.magic_barier = magic_barier;
            return tmp;
        }
    }
}