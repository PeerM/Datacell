using System.Collections;
using System.Collections.Generic;
using ItemSystem;
using UnityEngine;
using UnityEngine.UI;

public class ItemDisplay : Tooltip<Item>
{
    public Text body;

    protected override void _update(Item thing)
    {
        body.text = thing.ToString();
    }
}