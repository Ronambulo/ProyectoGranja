using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;

public class Slots_HUD : MonoBehaviour
{
    public Image itemIcon;
    public TextMeshProUGUI textoCantidad;

    public void SetItem(Inventory.Slot slot)
    {
        if (slot != null)
        {
            itemIcon.sprite = slot.icon;
            itemIcon.color = new Color(1, 1, 1, 1);
            if (slot.Count != 1)
            {
                textoCantidad.text = slot.Count.ToString();
            }
            else
            {
                textoCantidad.text = "";
            }

        }

    }

    public void SetEmpty()
    {
        itemIcon.sprite = null;
        itemIcon.color = new Color(1, 1, 1, 0);

        textoCantidad.text = "";
    }
}
