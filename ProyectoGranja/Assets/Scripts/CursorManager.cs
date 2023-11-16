using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class CursorManager : MonoBehaviour
{
    [SerializeField] public Player player;
    [SerializeField] public Texture2D cursorDefault;
    [SerializeField] public Texture2D cursorAtaque;
    [SerializeField] public GameObject inventoryPanel;
    [SerializeField] public GameObject pauseMenu;
    [SerializeField] public Tilemap interactableMap;
    [SerializeField] public Tilemap floor;
    private Grid grid;

    private Vector2 cursorHotspot;

    private Vector2 cursorPosition;
    private Vector2 previousCursorPosition = new Vector2();

    void Start()
    {
<<<<<<< Updated upstream
        cursorHotspot = new Vector2(cursorDefault.width / 2, cursorDefault.height / 2);
=======
        grid = gameObject.GetComponent<Grid>();
        cursorHotspot = new Vector2(cursorDefault.width/ divisor, cursorDefault.height/ divisor);
>>>>>>> Stashed changes
        Cursor.SetCursor(cursorDefault,cursorHotspot, CursorMode.Auto);
    }

    // Update is called once per frame
    void Update()
    {

<<<<<<< Updated upstream
        if (&& inventoryPanel.activeSelf == false)
        {
            Cursor.visible = true;
            cursorHotspot = new Vector2(cursorDefault.width / 2, cursorDefault.height / 2);
=======
        if ((inventoryPanel.activeSelf == false || pauseMenu.activeSelf == false))
        {
            Cursor.visible = true;
>>>>>>> Stashed changes
            Cursor.SetCursor(cursorAtaque, cursorHotspot, CursorMode.Auto);
        }
        else
        {
            if (inventoryPanel.activeSelf==true)
            {
                Cursor.visible = true;
<<<<<<< Updated upstream
                cursorHotspot = new Vector2(cursorDefault.width / 2, cursorDefault.height / 2);
                Cursor.SetCursor(cursorDefault cursorHotspot, CursorMode.Auto);
=======
                Cursor.SetCursor(cursorDefault, cursorHotspot, CursorMode.Auto);
>>>>>>> Stashed changes
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
