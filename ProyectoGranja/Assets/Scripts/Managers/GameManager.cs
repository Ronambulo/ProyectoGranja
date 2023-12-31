using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public string ThisScene;
    public string LastScene;
    public Transform player;
    public GameObject toolbar;
    public GameObject healthBar;
    public GameObject CanvasDontDestroy;
    public GameObject InventoryParent;
    public GameObject pausePanel;
    public GameObject muertePanel;

    private GameObject other;
    private EmoteManager emoteManager;
    public GameObject interiorTPObject;
    public ItemManager itemManager;
    public Inventory_UI inventoryUI;


    int i = 0;

    public Music musica;


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
            healthBar.SetActive(false);
        }
        else if (ThisScene == "EscenaCasaPlayer" && LastScene == "")
        {
            player.position = new Vector3(1.88f, -1.7f, -0.01f);
            toolbar.SetActive(false);
            healthBar.SetActive(false);
        }
        else if (ThisScene == "EscenaGranja" && LastScene == "EscenaCasaPlayer")
        {
            player.position = new Vector3(-1.270355f, 0.5595689f, -0.01f);
            toolbar.SetActive(true);
            healthBar.SetActive(true);
        }
        else if (ThisScene == "EscenaMazmorraFuera" && LastScene == "EscenaGranja") {
            player.position = new Vector3(0.03f, -8.14f, -0.01f);
        }
        else if (ThisScene == "EscenaMazmorraDentro" && LastScene == "EscenaMazmorraFuera") {
            player.position = new Vector3(-2.494712f, -7.835793f, -0.01f);
        }
        else if (ThisScene == "EscenaMazmorraFuera" && LastScene == "EscenaMazmorraDentro") {
            player.position = new Vector3(0.2467017f, 1.883749f, -0.01f);
        }
        else if (ThisScene == "EscenaGranja" && LastScene == "EscenaMazmorraFuera")
        {
            player.position = new Vector3(-5.58f, 2.329f, -0.01f);
        }

        //Cuando mueres, aparecen de nuevo, por ello tenemos que especificar que cuando estamos dentro de la casa no aparezcan
        if (ThisScene == "EscenaCasaPlayer") {
            toolbar.SetActive(false);
            healthBar.SetActive(false);
        }

        emoteManager = interiorTPObject.GetComponent<EmoteManager>();
        emoteManager.interact = false;
    }

    private void Update()
    {
        if (ThisScene == "TitleScreen")
        {
            player.gameObject.SetActive(true);
            toolbar.gameObject.SetActive(false);
            healthBar.gameObject.SetActive(false);
            CanvasDontDestroy.SetActive(false);
            pausePanel.gameObject.SetActive(false); 
            muertePanel.gameObject.SetActive(false);
        }
        else
        {
            if (ThisScene != "EscenaCasaPlayer")
            {
                toolbar.gameObject.SetActive(true);
                healthBar.gameObject.SetActive(true);
            }
            else{
                muertePanel.gameObject.SetActive(false);
            }

            CanvasDontDestroy.SetActive(true);
            if(i == 0)
            {
                inventoryUI.toggleInventory();
                i++;
            }   
            if (InventoryParent.activeSelf == true){
                player.gameObject.SetActive(false);
            }else{ 
                player.gameObject.SetActive(true); 
            }
        }
    

    }

    private void OnSceneUnloaded(Scene scene, LoadSceneMode mode) {
        LastScene = SceneManager.GetActiveScene().name;
        //interiorTPObject = transform.Find("Emotes").gameObject;
        //emoteManager = interiorTPObject.GetComponent<EmoteManager>();
        //emoteManager.interact = false;
    }

}
