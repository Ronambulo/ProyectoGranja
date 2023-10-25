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

    private EmoteManager emoteManager;
    public GameObject interiorTPObject;


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
        player = GameObject.FindWithTag("Player").transform;


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
            player.position = new Vector3(-4.913f, 0.696f, -0.01f);
        }
        else if (ThisScene == "EscenaCasaPlayer" && LastScene == "EscenaGranja")
        {
            player.position = new Vector3(0f, -2.146401f, -0.01f);
        }
        else if(ThisScene == "EscenaGranja" && LastScene == "EscenaCasaPlayer")
        {
            player.position = new Vector3(-1.270355f, 0.5595689f, -0.01f);
        }

        emoteManager = interiorTPObject.GetComponent<EmoteManager>();
        emoteManager.interact = false;

    }

    private void OnSceneUnloaded(Scene scene, LoadSceneMode mode) {
        LastScene = SceneManager.GetActiveScene().name;
        //interiorTPObject = transform.Find("Emotes").gameObject;
        emoteManager = interiorTPObject.GetComponent<EmoteManager>();
        emoteManager.interact = false;
    }
}
