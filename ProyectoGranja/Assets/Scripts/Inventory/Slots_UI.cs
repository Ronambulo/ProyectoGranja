using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;

public class Slots_UI : MonoBehaviour
{
    public Image itemIcon;
    public TextMeshProUGUI textoCantidad;

    public void SetItem(Inventory.Slot slot)
    {
        if(slot != null) { 
            itemIcon.sprite = slot.icon;
            itemIcon.color = new Color(1, 1, 1, 1);

            textoCantidad.text = slot.Count.ToString();
        }

    }

    public void SetEmpty()
    {
        itemIcon.sprite = null;
        itemIcon.color = new Color(1, 1, 1, 0);

        textoCantidad.text = "";
    }
}
