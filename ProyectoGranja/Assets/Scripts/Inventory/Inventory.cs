using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using UnityEngine;
using UnityEngine.Rendering;
using static Collectable;


[System.Serializable]
public class Inventory
{
    [System.Serializable]
    public class Slot
    {
        public string itemName;
        public int maxCount;
        public int Count;
        public Sprite icon;

        public Slot(){
            itemName = "";
            Count = 0;
            maxCount = 64;
        }

        public bool isEmpty
        {
            get
            {
                if(itemName == "" && Count == 0)
                {
                    return true;
                }
                return false;
            }
        }

        public bool canAddItem(string itemName)
        {
            if(this.itemName == itemName && Count < maxCount) {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void AddItem(Item item)
        {
            this.itemName = item.data.itemName;
            this.icon = item.data.icon;
            this.maxCount = item.data.maxCount;
            Count++;

        }

        public void AddItem(string itemName, Sprite icon, int MaxAllowed)
        {
            this.itemName = itemName;
            this.icon = icon;
            Count++;
            this.maxCount = MaxAllowed;
        }

        public void removeItem()
        {
            if(Count > 0)
            {
                Count--;
                
                if(Count == 0)
                {
                    icon = null;
                    itemName = "";
                }
            }
        }

    }

    public List<Slot> slots = new List<Slot>(); 

    public Inventory(int numSlots) {
        for (int i = 0; i < numSlots; i++)
        {
            Slot slot = new Slot();
            slots.Add(slot);
        }
    }

    public void Add(Item item)
    {
        foreach (Slot slot in slots)
        {
            if(slot.itemName == item.data.itemName && slot.canAddItem(item.data.itemName))
            {
                slot.AddItem(item);
                return;
            }
        }

        foreach (Slot slot in slots)
        {
            if(slot.itemName == "")
            {
                slot.AddItem(item);
                return;
            }
        }

    }

    public void Remove(int index)
    {
        slots[index].removeItem();
    }

    public void Remove(int index, int numToRemove)
    {
        if (slots[index].Count >= numToRemove)
        {
            for(int i = 0; i < numToRemove; i++)
            {
                Remove(index);
            }
        }
    }

    public void moveSlot(int fromIndex, int toIndex) { 
        Slot fromSlot = slots[fromIndex];
        Slot toSlot = slots[toIndex];

        if(toSlot.isEmpty || toSlot.canAddItem(fromSlot.itemName))
        {
            toSlot.AddItem(fromSlot.itemName, fromSlot.icon, fromSlot.maxCount);
            fromSlot.removeItem();
        }
    }


}
