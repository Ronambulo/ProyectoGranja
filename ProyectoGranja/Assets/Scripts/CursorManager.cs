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

    private List<string> listaEspadas;
    string objetoEnMano = null;

    private int divisor = 10;
    private Vector2 cursorHotspot;

    private Vector2 cursorPosition;
    private Vector2 previousCursorPosition = new Vector2();

    void Start()
    {
        cursorHotspot = new Vector2(cursorDefault.width/ divisor, cursorDefault.height/ divisor);
        Cursor.SetCursor(cursorDefault,cursorHotspot, CursorMode.Auto);
        listaEspadas.Add("diamondSword");
        listaEspadas.Add("goldSword");
        listaEspadas.Add("bronzeSword");
        listaEspadas.Add("ironSword");
    }

    // Update is called once per frame
    void Update()
    {
        objetoEnMano = toolBar_UI.nombreSeleccionado;

        if (inventoryPanel.activeSelf == false&&listaEspadas.Contains(objetoEnMano))
        {
            Cursor.visible = true;
            cursorHotspot = new Vector2(cursorDefault.width / divisor, cursorDefault.height / divisor);
            Cursor.SetCursor(cursorAtaque, cursorHotspot, CursorMode.Auto);
        }
        else
        {
            if (inventoryPanel.activeSelf==true||pauseMenu.activeSelf==true)
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

    void tileHover()
    {

    }
}
