using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    public CollectableType type;
    public Sprite icon;
    public int maxCount = 64;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player player = collision.gameObject.GetComponent<Player>();

        if (player)
        {
            player.inventory.Add(this);
            Destroy(this.gameObject);
        }
    }

    public enum CollectableType
    {
        NONE,
        CarrotSeed,
        StrawberrySeed,
        TomatoSeed,



        CarrotItem,
        StrawberryItem,
        TomatoItem,



        StoneItem,
        CopperItem,
        GoldItem,
        DiamondItem,

        Axe,
        Pickaxe,
        Hoe,


        StoneSword,
        CopperSword,
        GoldSword,
        DiamondSword

    }
}
