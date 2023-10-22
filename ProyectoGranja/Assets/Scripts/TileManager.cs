using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileManager : MonoBehaviour
{

    [SerializeField] private Tilemap interactableMap;

    [SerializeField] private Tile hiddenInteractableTile;

    void Start()
    {
        foreach(var position in interactableMap.cellBounds.allPositionsWithin) {
            interactableMap.SetTile(position, hiddenInteractableTile);
        }
    }

}
