using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Añadimos libreria de UI
using UnityEngine.UI;

public class UiHealthInteractiveHealthStamina : MonoBehaviour
{
   // public Image healthBar;
    public Image[] healthPoints;

    public float vida, vidaMax = 100;

    // Start is called before the first frame update
    void Start()
    {
        //Inicializamos la vida al máximo
        vida = vidaMax;
    }

    // Update is called once per frame
    void Update()
    {
        RellenaVida();

        //Por si se rebasa la vida del jugador de la vida máxima
        if(vida > vidaMax){
            vida = vidaMax;
        }
    }

    void RellenaVida(){

        for(int i = 0 ; i< healthPoints.Length ;i++){
            healthPoints[i].enabled = !MostrarPuntoDeSalud(vida, i);
        }
    }

    //daño*
    public void Danio(float danioPuntos){
        if(vida  > 0){
            vida -= danioPuntos;
        }
    }

    public void Recuperacion(float puntosRecuperacion){
        if(vida < vidaMax){
            vida+=puntosRecuperacion;
        }
    }

    bool MostrarPuntoDeSalud(float vida, int numeroPunto){
        //para mostrar la salud
        return ((numeroPunto*10) >= vida);
    }
}
