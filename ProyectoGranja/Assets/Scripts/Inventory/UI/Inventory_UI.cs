using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Inventory_UI : MonoBehaviour
{
    [SerializeField] public GameObject inventoryPanel;
    [SerializeField] public GameObject HUD;
    [SerializeField] public Player player;
    [SerializeField] public GameObject playerObject;

    

    public List<Slots_UI> slots = new List<Slots_UI>();
    //public List<Slots_HUD> slotshud = new List<Slots_HUD> ();

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            toggleInventory();
        }

        if (!inventoryPanel.activeSelf)
        {
            playerObject.SetActive(true);
        }

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

        /*if (slotshud.Count == player.inventory.slots.Count - 18)
        {
            for (int i = 0; i < slotshud.Count; i++)
            {
                if (player.inventory.slots[i].type != Collectable.CollectableType.NONE)
                {
                    slotshud[i].SetItem(player.inventory.slots[i]);
                }
                else
                {
                    slotshud[i].SetEmpty();
                }
            }

        }*/

    }

    public void toggleInventory()
    {
        if (!inventoryPanel.activeSelf)
        {
            inventoryPanel.SetActive(true);
            playerObject.SetActive(false);
            HUD.SetActive(true);

        }
        else
        {
            inventoryPanel.SetActive(false);
            playerObject.SetActive(true);
            if(SceneManager.GetActiveScene().name != "EscenaCasaPlayer")
                HUD.SetActive(true);
        }
    }
}
