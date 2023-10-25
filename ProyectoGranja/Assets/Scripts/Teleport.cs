using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Teleport : MonoBehaviour
{

    public enum TransitionType { Warp, Scene, Interior }
    [SerializeField] TransitionType transitionType;
    [SerializeField] string transitionTo;
    [SerializeField] object transitionToWarp;
    private GameManager gameManagerScript;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            switch (transitionType)
            {
                case TransitionType.Warp:
                    
                    break;
                case TransitionType.Scene:
                    GameObject gameManager = GameObject.FindWithTag("GameManager");
                    gameManagerScript = gameManager.GetComponent<GameManager>();
                    gameManagerScript.LastScene = SceneManager.GetActiveScene().name;
                    SceneManager.LoadScene(transitionTo);
                    break;
                 case TransitionType.Interior:
                    break;
            }
        }
    }
}
