using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject pausePanel;

    public bool isPaused;

    void Start()
    {
        pausePanel.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) {

            if (isPaused)
            {
                Continue();
            }
            else {
                Pause();
            }
        }
    }

    public void Pause() {

        pausePanel.SetActive(true);
        //PAUSA EL JUEGO
        Time.timeScale = 0;
    }

    public void Continue()
    {
        pausePanel.SetActive(false);
        //VUELVE A SEGUIR EL JUEGO
        Time.timeScale = 1;
    }
}
