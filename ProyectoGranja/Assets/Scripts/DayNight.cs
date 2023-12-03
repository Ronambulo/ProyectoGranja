using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNight : MonoBehaviour
{
    //Control momento dia
    public bool esDeDia;
    private GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        // if (gameManager.isJuego){
        //     gameManager.tiempo += Time.deltaTime;
        //     testSignificantTime();
        // }

    }

    public void testSignificantTime(){
        //Resetear tiempo cuando pasan 24 min (24 horas en juego)
        // if (gameManager.tiempo == 1440){
        //     gameManager.tiempo = 0;
        // }

        // if (gameManager.tiempo >= 0 && gameManager.tiempo <= 540) {
        //     esDeDia = true;
        // } else {
        //     esDeDia = false;
        // }
    }
}
