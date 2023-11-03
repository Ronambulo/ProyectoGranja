using System.Collections;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;

public class ToolBar_UI : MonoBehaviour
{

    [SerializeField] public Player player;


    public List<Slots_HUD> slotshud = new List<Slots_HUD>();

    private Slots_HUD SelectedSlot;

    public void SelectSlot(int index)
    {
        if(slotshud.Count == 9)
        {
            if(SelectedSlot != null)
            {
                SelectedSlot.setHighlight(true);
            }
            SelectedSlot = slotshud[index];
            SelectedSlot.setHighlight(false);

        }
    }

    private void CheckAlphaNumericKeys()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1)) { SelectSlot(0); }
        if (Input.GetKeyDown(KeyCode.Alpha2)) { SelectSlot(1); }
        if (Input.GetKeyDown(KeyCode.Alpha3)) { SelectSlot(2); }
        if (Input.GetKeyDown(KeyCode.Alpha4)) { SelectSlot(3); }
        if (Input.GetKeyDown(KeyCode.Alpha5)) { SelectSlot(4); }
        if (Input.GetKeyDown(KeyCode.Alpha6)) { SelectSlot(5); }
        if (Input.GetKeyDown(KeyCode.Alpha7)) { SelectSlot(6); }
        if (Input.GetKeyDown(KeyCode.Alpha8)) { SelectSlot(7); }
        if (Input.GetKeyDown(KeyCode.Alpha9)) { SelectSlot(8); }
    }


    private void Start()
    {
        SelectSlot(0);  
    }

    void Update()
    {

        if (slotshud.Count == player.inventory.slots.Count - 18)
        {
            for (int i = 0; i < slotshud.Count; i++)
            {
                if (player.inventory.slots[i].itemName != "")
                {
                    slotshud[i].SetItem(player.inventory.slots[i]);
                }
                else
                {
                    slotshud[i].SetEmpty();
                }
            }

        }

        CheckAlphaNumericKeys();

    }
}
