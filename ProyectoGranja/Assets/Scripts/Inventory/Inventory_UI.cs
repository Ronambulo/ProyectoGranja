using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory_UI : MonoBehaviour
{
    [SerializeField] public GameObject inventoryPanel;
    [SerializeField] public Player player;
    [SerializeField] public GameObject playerObject;

    

    public List<Slots_UI> slots = new List<Slots_UI>();


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            toggleInventory();
        }
    }

    public void toggleInventory()
    {
        if (!inventoryPanel.activeSelf)
        {
            inventoryPanel.SetActive(true);
            playerObject.SetActive(false);
            Setup();
        }
        else
        {
            inventoryPanel.SetActive(false);
            playerObject.SetActive(true);
        }
    }

    void Setup()
    {
        if (slots.Count == player.inventory.slots.Count)
        {
            for (int i = 0; i < slots.Count; i++)
            {
                if (player.inventory.slots[i].type != Collectable.CollectableType.NONE)
                {
                    slots[i].SetItem(player.inventory.slots[i]);
                }
                else
                {
                    slots[i].SetEmpty();
                }
            }

        }
    }
}
