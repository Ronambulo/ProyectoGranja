using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using static UnityEngine.GraphicsBuffer;

public class TileManager : MonoBehaviour
{

    [SerializeField] private Tilemap interactableMap;
    [SerializeField] public string nombreBuscado;
    [SerializeField] private Tile hiddenInteractableTile;

    void Update()
    {
        Tilemap[] tilemaps = FindObjectsOfType<Tilemap>();
        foreach (Tilemap tilemap in tilemaps)
        {
            if (tilemap.name == nombreBuscado)
            {
                interactableMap = tilemap;
                foreach (var position in interactableMap.cellBounds.allPositionsWithin)
                {
                    interactableMap.SetTile(position, hiddenInteractableTile);
                }


            }
        }
        
    }
    
}
