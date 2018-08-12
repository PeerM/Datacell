using System;
using System.Globalization;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.UI;

public class CombatantDisplay : MonoBehaviour
{
    public GameObject window;
    public Combatant target;

    public Text text_name;
    public Text healt;
    public Text attackPower;
    public Text armor;
    public Text magic_armor;

    public void show(Combatant that)
    {
        target = that;
        window.SetActive(true);
    }

    public void showNothing()
    {
        target = null;
        window.SetActive(false);
    }

    private void Awake()
    {
/*        if (target == null)
        {
            window.SetActive(false);
        }
        else
        {
            window.SetActive(true);
        }*/
    }

    private void Update()
    {
        if (target != null)
        {
            text_name.text = target.combetant_name;
            healt.text = target.health.ToString();
            attackPower.text = target.stats.attack_power.ToString();
            armor.text = target.stats.armor.ToString();
            magic_armor.text = String.Format("{0:0.#\\%}", target.stats.magic_barier * 100);
        }
    }
}