using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Inventory_UI : MonoBehaviour
{
    [SerializeField] public GameObject inventoryPanel;
    [SerializeField] public GameObject HUD;
    [SerializeField] public GameObject pausaPanel;
    [SerializeField] public Player player;
    [SerializeField] public GameObject playerObject;
    [SerializeField] private GameObject healthBar;
    [SerializeField] private Canvas canvas;

    private bool dragSingle;

    private Slots_UI draggedSlot;
    private Image draggedIcon;

    public GameManager gameManager;
    public Item ItemToDrop;


    public List<Slots_UI> slots = new List<Slots_UI>();
    //public List<Slots_HUD> slotshud = new List<Slots_HUD> ();


    private void Awake()
    {
        Refresh();
        toggleInventory();
        canvas = FindAnyObjectByType<Canvas>();
    }

    private void Start()
    {
        SetupSlots();
        Refresh();
        toggleInventory();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (!pausaPanel.activeSelf) {
                Refresh();
                inventoryPanel.GetComponent<RectTransform>().localPosition = new Vector3(0, 0, 0);
                toggleInventory();
            }

        }
        if(Input.GetKeyDown(KeyCode.E)){
            Refresh();
        }

        if(Input.GetKey(KeyCode.LeftShift)) 
        {
            dragSingle = true;
        }
        else
        {
            dragSingle = false;
        }

        if (Input.GetKeyDown(KeyCode.Escape)) {
            togglePause();
        }

        if (!inventoryPanel.activeSelf)
        {
            playerObject.SetActive(true);
        }
    }

    public void toggleInventory()
    {
        if (inventoryPanel != null)
        {
            if (!inventoryPanel.activeSelf)
            {
                inventoryPanel.SetActive(true);
                healthBar.SetActive(true);
                playerObject.SetActive(false);
                HUD.SetActive(true);
                Refresh();

            }
            else
            {
                inventoryPanel.SetActive(false);
                playerObject.SetActive(true);
                if (SceneManager.GetActiveScene().name != "EscenaCasaPlayer")
                    HUD.SetActive(true);
                    healthBar.SetActive(true);
            }
        }
        
    }

    public void Refresh()
    {
        if (slots.Count == player.inventory.slots.Count)
        {
            for (int i = 0; i < slots.Count; i++)
            {
                if (player.inventory.slots[i].itemName != "")
                {
                    slots[i].SetItem(player.inventory.slots[i]);
                }
                else
                {
                    slots[i].SetEmpty();
                }

            }
        }
        else if (slots.Count == player.toolbar.slots.Count)
        {
            for (int i = 0; i < slots.Count; i++)
            {
                if (player.toolbar.slots[i].itemName != "")
                {
                    slots[i].SetItem(player.toolbar.slots[i]);
                }
                else
                {
                    slots[i].SetEmpty();
                }

            }
        }
    }


    public void Remove()
    {
        ItemToDrop = gameManager.itemManager.GetItemByName(player.inventory.slots[draggedSlot.slotID].itemName);
        if (ItemToDrop != null)
        {
            if (dragSingle)
            {
                player.DropItem(ItemToDrop);
                player.inventory.Remove(draggedSlot.slotID);
            }
            else
            {
                player.DropItem(ItemToDrop, player.inventory.slots[draggedSlot.slotID].Count);
                player.inventory.Remove(draggedSlot.slotID, player.inventory.slots[draggedSlot.slotID].Count);
            }

            Refresh();
        }

        draggedSlot = null; 

    }

    public void SlotBeginDrag(Slots_UI slot)
    {
        draggedSlot = slot;
        draggedIcon = Instantiate(draggedSlot.itemIcon);
        draggedIcon.transform.SetParent(canvas.transform);
        draggedIcon.raycastTarget = false;
        draggedIcon.rectTransform.sizeDelta = new Vector2(100,100);

        MoveToMousePosition(draggedIcon.gameObject);
        Debug.Log("start drag: " + draggedSlot.name);
    }

    public void SlotDrag()
    {
        Debug.Log("Dragging: "+ draggedSlot.name);
        MoveToMousePosition(draggedIcon.gameObject);
    }

    public void SlotEndDrag()
    {
        Destroy(draggedIcon.gameObject);
        draggedIcon = null;
        Debug.Log("Dragged finish: " + draggedSlot.name);
    }

    public void SlotDrop(Slots_UI slot)
    {
        player.inventory.moveSlot(draggedSlot.slotID, slot.slotID);
        Refresh();
        Debug.Log("Dropped " + draggedSlot.name + " on " + slot.name);
    }

    private void MoveToMousePosition(GameObject toMove)
    {
        if(canvas != null)
        {
            Vector2 position;
            RectTransformUtility.ScreenPointToLocalPointInRectangle(canvas.transform as RectTransform, Input.mousePosition, null, out position);

            toMove.transform.position = canvas.transform.TransformPoint(position);
        }
    }


    public void togglePause()
    {

        if (!pausaPanel.activeSelf) {
            inventoryPanel.SetActive(false);
            playerObject.SetActive(false);
            pausaPanel.SetActive(true);

            Time.timeScale = 0;
        }
        else {
            Resume();
        }
    }
    public void Resume()
    {
        Time.timeScale = 1f;
        pausaPanel.SetActive(false);
        playerObject.SetActive(true);
    }

    //para el panel de pausa
    public void GoToMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("TitleScreen");
    }
    public void QuitGame()
    {
        Application.Quit();
    }

    private void SetupSlots()
    {
        int counter = 0;
        foreach(Slots_UI slots in slots)
        {
            slots.slotID = counter;
            counter++;
        }
    }
}
