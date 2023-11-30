using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Añadimos libreria de UI
using UnityEngine.UI;

public class UiHealthInteractiveHealthStamina : MonoBehaviour
{
    public DamageableCharacter playerHealth;
    public PlayerController playerStamina;

   // public Image healthBar;
    public Image[] healthPoints;
    public Image[] staminaPoints;

    public int stamina;
    public float vida, vidaMax = 8;

    // Start is called before the first frame update
    void Start()
    {
        //Inicializamos la vida al máximo
        vida = playerHealth.VidaCharacter;
    }

    // Update is called once per frame
    void Update()
    {
        vida = playerHealth.VidaCharacter;
        stamina = playerStamina.StaminaCharacter;

        RellenaVida();
        RellenaStamina();

        //Por si se rebasa la vida del jugador de la vida máxima
        if(vida > vidaMax){
            vida = vidaMax;
        }
    }

    void RellenaVida(){
        for(int i = 0 ; i < healthPoints.Length ;i++){
            healthPoints[i].enabled = !MostrarPuntoDeSalud(vida, i);
        }
    }
    void RellenaStamina()
    {
        for (int i = 0; i < staminaPoints.Length; i++)
        {
            staminaPoints[i].enabled = !MostrarPuntoDeStamina(stamina, i);
        }
    }

    bool MostrarPuntoDeSalud(float vida, int numPunto){
        //para mostrar la salud
        return (numPunto >= vida);
    }

    bool MostrarPuntoDeStamina(int stamina, int numPunto) {
        return ((numPunto*10) >= stamina);
    }
}
