using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.SceneManagement;
using static UnityEngine.GraphicsBuffer;

public class TileManager : MonoBehaviour
{

    [SerializeField] private Tilemap interactableMap;
    [SerializeField] public string nombreBuscado;
    [SerializeField] private Tile hiddenInteractableTile;

    private Scene prevScene = new Scene();

    void Update()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        if (!currentScene.Equals(prevScene))
        { 
                Tilemap[] tilemaps = FindObjectsOfType<Tilemap>();
            foreach (Tilemap tilemap in tilemaps)
            {
                if (tilemap.name == nombreBuscado)
                {
                    interactableMap = tilemap;
                    foreach (var position in interactableMap.cellBounds.allPositionsWithin)
                    {
                        if (interactableMap.GetTile(position) != null)
                        {
                            interactableMap.SetTile(position, hiddenInteractableTile);
                        }
                    }


                }
            }
        }
    }
    
}
