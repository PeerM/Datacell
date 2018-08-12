using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters;
using combat;
using ItemSystem;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Combatant))]
public class Player : MonoBehaviour
{
    private Rigidbody2D rb2D;
    public Combatant combat;
    public Stats base_stats;
    public string game_over_name;
    public List<Item> items;
    public int max_slots = 6;
    public PlayerInventory inventory;
    [SerializeField] private ItemContainer on_item;

    void Awake()
    {
        rb2D = gameObject.GetComponent<Rigidbody2D>();
        combat.handle_death = () => SceneManager.LoadScene(game_over_name);
        reloadItems();
    }

    void Update()
    {
        if (Input.GetButtonDown("Activate"))
        {
            if (on_item)
            {
                bool success = Add(on_item.contained);
                if (success)
                {
                    Destroy(on_item.gameObject);
                    on_item = null;
                }

                return;
            }
        }

        // movment
        var direction_instruction = new Dictionary<string, Vector3>
        {
            {"up", Vector3.up},
            {"down", Vector3.down},
            {"left", Vector3.left},
            {"right", Vector3.right},
        };
        var vec = Vector3.up;
        var should_move = false;
        foreach (var button in direction_instruction.Keys)
        {
            if (Input.GetButtonDown(button))
            {
                vec = direction_instruction[button];
                should_move = true;
            }
        }

        if (should_move)
        {
            var can_move = true;
            var mask = LayerMask.GetMask("level");
            var hit = Physics2D.Raycast(transform.position, vec, 2, mask);
            //TODO lower distance and remove distance check
            if (hit.collider != null)
            {
                float distance = Vector2.Distance(transform.position, hit.point);
                can_move = distance > 1;
                if (distance < 1)
                {
                    var enemy = hit.transform.gameObject.GetComponent<Enemy>();
                    if (enemy != null)
                    {
                        enemy.combat.attacked_by(this.combat);
                        can_move = false;
                    }
                    else
                    {
                        can_move = false;
                    }
                }
            }

            if (can_move)
            {
                rb2D.MovePosition(transform.position + vec);
            }
        }
    }

    void reloadItems()
    {
        var tmp = base_stats.clone();
        foreach (var item in items)
        {
            item.apply_to_stats(tmp);
        }

        combat.stats = tmp;

        inventory.reload(items, this);
    }

    public bool Add(Item item)
    {

        if (item.name == "winning")
        {
            SceneManager.LoadScene("won");
        }
        
        if (items.Count >= max_slots)
        {
            return false;
        }

        items.Add(item);
        reloadItems();
        return true;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        var item_container = other.GetComponent<ItemContainer>();
        if (item_container)
        {
            this.on_item = item_container;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        this.on_item = null;
    }

    public void remove_item(Item item)
    {
        items.Remove(item);
        reloadItems();
    }
}