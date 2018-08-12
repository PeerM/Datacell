using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Combatant))]
public class Enemy : MonoBehaviour
{
    public Combatant combat;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void Awake()
    {
        combat = GetComponent<Combatant>();
        combat.handle_death = die;
    }

    private void die()
    {
        Object.Destroy(this.gameObject);
    }
}