using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Content;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public string ThisScene;
    public string LastScene;
    public Transform player;

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
        switch (ThisScene)
        {

            case "EscenaCamino":
                Debug.Log("escenaCamino");
                player.position = new Vector3(-4.945f, 1.398f, -0.01f);
                break;

            case "EscenaGranja":
                Debug.Log("escenaGranja");
                player.position = new Vector3(5.07f, -0.3848993f, -0.01f);
                break;
        }

    }

    private void OnSceneUnloaded(Scene scene, LoadSceneMode mode) {
        LastScene = SceneManager.GetActiveScene().name;
    }
}
