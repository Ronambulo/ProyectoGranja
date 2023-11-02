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
        public CollectableType type;
        public int maxCount;
        public int Count;
        public Sprite icon;

        public Slot(){
            type = CollectableType.NONE;
            Count = 0;
            maxCount = 64;
        }

        public bool canAddItem()
        {
            if(Count < maxCount) {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void AddItem(Collectable item)
        {
            this.type = item.type;
            this.icon = item.icon;
            this.maxCount = item.maxCount;
            Count++;

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

    public void Add(Collectable item)
    {
        foreach (Slot slot in slots)
        {
            if(slot.type == item.type && slot.canAddItem())
            {
                slot.AddItem(item);
                return;
            }
        }

        foreach (Slot slot in slots)
        {
            if(slot.type == CollectableType.NONE)
            {
                slot.AddItem(item);
                return;
            }
        }

    }
}
