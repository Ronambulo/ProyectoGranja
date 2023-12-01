using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class CursorManager : MonoBehaviour
{
    [SerializeField] public ToolBar_UI toolBar_UI;
    [SerializeField] public Texture2D cursorDefault;
    [SerializeField] public Texture2D cursorAtaque;
    [SerializeField] public GameObject inventoryPanel;
    [SerializeField] public GameObject pauseMenu;
    [SerializeField] public Tilemap interactableMap;
    [SerializeField] public Tilemap floor;

    private List<string> listaEspadas = new List<string> { "Diamond Sword", "Gold Sword", "Bronze Sword" , "Iron Sword" };
    private string objetoEnMano;

    private int divisor = 10;
    private Vector2 cursorHotspot;

    private Vector3Int previousCursorPosition = new Vector3Int();

    void Start()
    {
        cursorHotspot = new Vector2(cursorDefault.width/ divisor, cursorDefault.height/ divisor);
        Cursor.SetCursor(cursorDefault,cursorHotspot, CursorMode.Auto);
    }

    // Update is called once per frame
    void Update()
    {
        //Vector3Int cursorPosition = GetMousePosition(); no encuentra GetMousePosition 
        objetoEnMano = toolBar_UI.nombreSeleccionado;

        Tilemap[] tilemaps = FindObjectsOfType<Tilemap>();
        foreach (Tilemap tilemap in tilemaps)
        {
            if (tilemap.name == "interactableMap")
            {
                interactableMap = tilemap;
            }
            if(tilemap.name == "Floor")
            {
                floor = tilemap;
            }
        }

        if (!cursorPosition.Equals(previousCursorPosition))
        {

        }

        if (inventoryPanel.activeSelf == false && listaEspadas.Contains(objetoEnMano))
        {
            Cursor.visible = true;
            cursorHotspot = new Vector2(cursorDefault.width / divisor, cursorDefault.height / divisor);
            Cursor.SetCursor(cursorAtaque, cursorHotspot, CursorMode.Auto);
        }
        else
        {
            if (inventoryPanel.activeSelf == true || pauseMenu.activeSelf == true)
            {
                Cursor.visible = true;

                cursorHotspot = new Vector2(cursorDefault.width / divisor, cursorDefault.height / divisor);
                Cursor.SetCursor(cursorDefault, cursorHotspot, CursorMode.Auto);
            }
            else
            {
                Cursor.visible = false;
            }
                
        }
    }
}
