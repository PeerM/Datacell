using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

public class PlayerHealthInfo : MonoBehaviour
{
    public Player player;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        var display = GetComponent<InfoDisplay>();
        display.set_current(player.combat.health);
    }
}