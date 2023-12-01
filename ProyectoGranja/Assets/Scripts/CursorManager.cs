using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.SceneManagement;

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

    private Scene prevScene= new Scene();
    private bool gameStarted=false;

    void Start()
    {
        cursorHotspot = new Vector2(cursorDefault.width/ divisor, cursorDefault.height/ divisor);
        Cursor.SetCursor(cursorDefault,cursorHotspot, CursorMode.Auto);
    }

    // Update is called once per frame
    void Update()
    {
        Grid grid = FindObjectOfType<Grid>();
        Scene currentScene = SceneManager.GetActiveScene();
        if(currentScene.name=="EscenaGranja"&&!gameStarted)gameStarted=true;
        if (!currentScene.Equals(prevScene))
        {
            prevScene = currentScene;
            Tilemap[] tilemaps = FindObjectsOfType<Tilemap>();
            foreach (Tilemap tilemap in tilemaps)
            {
                if (tilemap.name == "interactableMap")
                {
                    interactableMap = tilemap;
                }
                if (tilemap.name == "Floor")
                {
                    floor = tilemap;
                }
            }
        }
        
        objetoEnMano = toolBar_UI.nombreSeleccionado;

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
                if (gameStarted == true && grid != null)
                {
                    Vector3Int cursorPosition = grid.WorldToCell(Camera.main.ScreenToWorldPoint(Input.mousePosition));
                    if (!cursorPosition.Equals(previousCursorPosition))
                    {
                        floor.SetTileFlags(previousCursorPosition, TileFlags.None);
                        floor.SetColor(previousCursorPosition, new Color(1f, 1f, 1f, 1f));
                        floor.SetTileFlags(cursorPosition, TileFlags.None);
                        floor.SetColor(cursorPosition, new Color(0.75f, 0.75f, 0.75f, 1f));
                        previousCursorPosition = cursorPosition;
                    }
                }
                Cursor.visible = false;
            }

        }
    }
}
