using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using combat;
using DefaultNamespace;
using UnityEditor;
using UnityEngine;

public class Combatant : MonoBehaviour
{
    public string combetant_name = "monster";
    public int health = 100;

    // magic resistance
    // physical resistance
    // armor
    public HandleDeath handle_death;

    public Stats _stats;

    public Stats stats
    {
        get { return _stats; }
        set
        {
            if (value.max_hp < health)
            {
                health = value.max_hp;
            }
            else if (value.max_hp > _stats.max_hp)
            {
                health += value.max_hp - _stats.max_hp;
            }

            _stats = value;
        }
    }

    public CombatantDisplay display;

    public delegate void HandleDeath();

    private void Awake()
    {
        var foundObjects = FindObjectsOfType<CombatantDisplay>();
        if (foundObjects.Length == 1)
        {
            this.display = foundObjects.First();
        }
        else
        {
            Debug.Log("not the right number of CombatantDisplay's");
        }
    }

    private void Start()
    {
        //maybee this should not be in awake
        health = stats.max_hp;
    }

    public void attacked_by(Combatant other)
    {
        var still_alive = b_attacks_a(this, other);
        if (still_alive)
        {
            b_attacks_a(other, this);
        }
        else
        {
            if (display)
            {
                display.showNothing();
            }
        }
    }

    private static bool b_attacks_a(Combatant a, Combatant b)
    {
        var damage = b.stats.attack_power - a.stats.armor;
        damage = (int) (damage * b.stats.magic_barier);
        a.health -= b.stats.attack_power;
        if (a.health <= 0)
        {
            a.handle_death();
            return false;
        }

        return true;
    }

    private void OnMouseEnter()
    {
        if (display)
        {
            display.show(this);
        }
    }

    private void OnMouseExit()
    {
        if (display)
        {
            display.showNothing();
        }
    }
}