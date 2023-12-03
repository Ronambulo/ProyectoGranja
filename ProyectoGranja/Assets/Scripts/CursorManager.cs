using System;
//using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.SceneManagement;

public class CursorManager : MonoBehaviour
{
    [SerializeField] public GameObject player;
    [SerializeField] public ToolBar_UI toolBar_UI;
    [SerializeField] public Texture2D cursorDefault;
    [SerializeField] public Texture2D cursorAtaque;
    [SerializeField] public GameObject inventoryPanel;
    [SerializeField] public GameObject pauseMenu;
    [SerializeField] public Tile []listaCultivo;

    private Tilemap crops;
    private Tilemap floor;

    private List<string> listaEspadas = new List<string> { "Diamond Sword", "Gold Sword", "Bronze Sword" , "Iron Sword" };
    private string objetoEnMano;
    private enum colores { noColor, red, green, gray }
    private List<Color> listaColores = new List<Color>{Color.white, Color.red, Color.green, new Color(0.75f, 0.75f, 0.75f, 1f) }; 


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
        Vector3Int playerPosition = new Vector3Int(
            Mathf.RoundToInt(player.transform.position.x),
            Mathf.RoundToInt(player.transform.position.y),
            Mathf.RoundToInt(player.transform.position.z)
            );
        Scene currentScene = SceneManager.GetActiveScene();
        objetoEnMano = toolBar_UI.nombreSeleccionado;
        Vector3Int cursorPosition = grid.WorldToCell(Camera.main.ScreenToWorldPoint(Input.mousePosition));
        bool boolReachable = Math.Abs(cursorPosition.x - playerPosition.x * 2) <= 3 && Math.Abs(cursorPosition.y - playerPosition.y * 2) <= 3;

        if (currentScene.name=="EscenaGranja"&&!gameStarted)
            gameStarted=true;
        if (!currentScene.Equals(prevScene))
        {
            prevScene = currentScene;
            Tilemap[] tilemaps = FindObjectsOfType<Tilemap>();
            foreach (Tilemap tilemap in tilemaps)
            {
                if (tilemap.name == "Crops")
                {
                    crops = tilemap;
                }
                if (tilemap.name == "Floor")
                {
                    floor = tilemap;
                }
            }
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
                if (gameStarted == true && grid != null)
                {
                    if (!cursorPosition.Equals(previousCursorPosition))
                    {
                        floor.SetTileFlags(previousCursorPosition, TileFlags.None);
                        floor.SetColor(previousCursorPosition, listaColores[(int)colores.noColor]);
                        if (objetoEnMano=="Azada" && currentScene.name == "EscenaGranja")
                        {
                            if (boolReachable)
                            {
                                floor.SetTileFlags(cursorPosition, TileFlags.None);
                                floor.SetColor(cursorPosition, listaColores[(int)colores.green]);
                            }
                            else
                            {
                                floor.SetTileFlags(cursorPosition, TileFlags.None);
                                floor.SetColor(cursorPosition, listaColores[(int)colores.red]);
                            }
                        }
                        else
                        {
                            floor.SetTileFlags(cursorPosition, TileFlags.None);
                            floor.SetColor(cursorPosition, listaColores[(int)colores.gray]);
                        }
                    }
                }
                Cursor.visible = false;
            }
            if (objetoEnMano == "Azada" && Input.GetMouseButtonDown(0) && crops.GetTile(cursorPosition).name == "Interact" && boolReachable)
            {
                floor.SetTile(cursorPosition, listaCultivo[new System.Random().Next(0, 3)]);
            }
            previousCursorPosition = cursorPosition;
        }
    }
}
