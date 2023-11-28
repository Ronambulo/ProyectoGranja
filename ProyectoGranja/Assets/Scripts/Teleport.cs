using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.SceneManagement;

public class Teleport : MonoBehaviour
{

    public enum TransitionType { Warp, Scene, Interior }
    [SerializeField] TransitionType transitionType;
    [SerializeField] string transitionTo;
    [SerializeField] object transitionToWarp;
    private GameManager gameManagerScript;

    public bool buttonE;
    public bool isPlayerInside;

    private void Update()
    {
       buttonE = Input.GetKey("e");
        if (isPlayerInside)
        {
            switch (transitionType)
            {
                case TransitionType.Warp:
                    SceneName();
                    break;
                case TransitionType.Scene:
                    SceneName();
                    SceneManager.LoadScene(transitionTo);
                    break;
                case TransitionType.Interior:
                    if (buttonE == true)
                    {
                        SceneName();
                        SceneManager.LoadScene(transitionTo);
                    }
                    break;
            }
        }
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInside = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInside = false;
        }
    }

    void SceneName()
    {
        GameObject gameManager = GameObject.FindWithTag("GameManager");
        gameManagerScript = gameManager.GetComponent<GameManager>();
        gameManagerScript.LastScene = SceneManager.GetActiveScene().name;
    }

}
