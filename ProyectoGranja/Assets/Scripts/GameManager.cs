using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Build.Content;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public string ThisScene;
    public string LastScene;
    public Transform player;
    public GameObject toolbar;
    public GameObject CanvasDontDestroy;
    public GameObject InventoryParent;

    private GameObject other;
    private EmoteManager emoteManager;
    public GameObject interiorTPObject;
    public ItemManager itemManager;
    public Inventory_UI inventoryUI;

    int i = 0;

    private void OnEnable()
    {
        SceneManager.sceneLoaded -= OnSceneUnloaded;
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded += OnSceneUnloaded;
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        ThisScene = SceneManager.GetActiveScene().name;
        //player = GameObject.FindWithTag("Player").transform;

        if (ThisScene == "EscenaGranja" && LastScene == "TitleScreen") { 
        
        }
        if (ThisScene == "EscenaCamino" && LastScene == "EscenaGranja")
        {
            player.position = new Vector3(-4.945f, 1.398f, -0.01f);
        }
        else if (ThisScene == "EscenaGranja" && LastScene == "EscenaCamino")
        {
            player.position = new Vector3(5.07f, -0.3848993f, -0.01f);
        }
        else if (ThisScene == "EscenaCamino" && LastScene == "EscenaPueblo")
        {
            player.position = new Vector3(5.07f, 1.398f, -0.01f);
        }
        else if (ThisScene == "EscenaPueblo" && LastScene == "EscenaCamino")
        {
            player.position = new Vector3(1.172709f, -0.9253911f, -0.01f);
        }
        else if (ThisScene == "EscenaCasaPlayer" && LastScene == "EscenaGranja")
        {
            player.position = new Vector3(0f, -2.146401f, -0.01f);
            toolbar.SetActive(false);
        }
        else if(ThisScene == "EscenaGranja" && LastScene == "EscenaCasaPlayer")
        {
            player.position = new Vector3(-1.270355f, 0.5595689f, -0.01f);
            toolbar.SetActive(true);
        }
        else if(ThisScene == "EscenaMazmorraFuera" && LastScene == "EscenaGranja"){
            player.position = new Vector3(0.04f, -8.523807f, -0.01f);
        }
        else if(ThisScene == "EscenaMazmorraDentro" && LastScene == "EscenaMazmorraFuera"){
            player.position = new Vector3(-2.494712f, -7.835793f, -0.01f);
        }
        else if(ThisScene == "EscenaMazmorraFuera" && LastScene == "EscenaMazmorraDentro"){
            player.position = new Vector3(0.2467017f, 1.883749f, -0.01f);
        }

        emoteManager = interiorTPObject.GetComponent<EmoteManager>();
        emoteManager.interact = false;

    }

    private void Update()
    {
        if (ThisScene == "TitleScreen")
        {
            player.gameObject.SetActive(false);
            toolbar.gameObject.SetActive(false);
            CanvasDontDestroy.SetActive(false);
        }
        else
        {
            if(ThisScene != "EscenaCasaPlayer")
            {
                toolbar.gameObject.SetActive(true);
            }

            CanvasDontDestroy.SetActive(true);
            if(i == 0)
            {
                inventoryUI.toggleInventory();
                i++;
            }   
            if (InventoryParent.activeSelf == true){player.gameObject.SetActive(false);}else{ player.gameObject.SetActive(true); }
        }

    }

    private void OnSceneUnloaded(Scene scene, LoadSceneMode mode) {
        LastScene = SceneManager.GetActiveScene().name;
        //interiorTPObject = transform.Find("Emotes").gameObject;
        emoteManager = interiorTPObject.GetComponent<EmoteManager>();
        emoteManager.interact = false;
    }
}
