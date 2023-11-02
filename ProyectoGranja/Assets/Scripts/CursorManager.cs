using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorManager : MonoBehaviour
{

    [SerializeField] public Texture2D cursorDefault;
    [SerializeField] public Texture2D cursorAtaque;
    [SerializeField] public GameObject inventoryPanel;
    [SerializeField] public GameObject hotbar;

    private Vector2 cursorHotspot;

    void Start()
    {
        cursorHotspot = new Vector2(cursorDefault.width / 2, cursorDefault.height / 2);
        Cursor.SetCursor(cursorDefault,cursorHotspot, CursorMode.Auto);
    }

    // Update is called once per frame
    void Update()
    {

        if (&& inventoryPanel.activeSelf == false)
        {
            Cursor.visible = true;
            cursorHotspot = new Vector2(cursorDefault.width / 2, cursorDefault.height / 2);
            Cursor.SetCursor(cursorAtaque, cursorHotspot, CursorMode.Auto);
        }
        else
        {
            if (inventoryPanel.activeSelf==true)
            {
                Cursor.visible = true;
                cursorHotspot = new Vector2(cursorDefault.width / 2, cursorDefault.height / 2);
                Cursor.SetCursor(cursorDefault cursorHotspot, CursorMode.Auto);
            }
            else
            {
                Cursor.visible = false;
            }

        }
    }
}
