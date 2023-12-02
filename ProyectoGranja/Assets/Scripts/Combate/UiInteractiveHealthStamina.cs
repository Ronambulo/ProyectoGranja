using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Añadimos libreria de UI
using UnityEngine.UI;
//Añadimos librería de TMP para texto
using TMPro;
//Añadimos librería para cambiar de escena cuando mueras
using UnityEngine.SceneManagement;

public class UiHealthInteractiveHealthStamina : MonoBehaviour
{
    public DamageableCharacter playerHealth;
    public PlayerController playerStamina;

    // public Image healthBar;
    public Image[] healthPoints;
    public Image[] staminaPoints;

    public int stamina;
    public float vida, vidaMax = 8;

    public TMP_Text vidaText;
    public TMP_Text staminaText;

    public GameObject muertePanel;
    public string vueltaACasa;
 

    //COLORES
    public Color color1;
    public Color color2;
    public Color color3;
    public Color color4;
    public Color color5;
    public Color color6;
    public Color color7;
    public Color color8;


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

        vidaText.text = "" + vida;
        vidaText.color = Color.red;

        staminaText.text = "" + stamina;

        RellenaVida();
        RellenaStamina();
        //ColoresTexto(vida, stamina);


        //Por si se rebasa la vida del jugador de la vida máxima
        if (vida > vidaMax) {
            vida = vidaMax;
        }
    }

    void RellenaVida() {
        for (int i = 0; i < healthPoints.Length; i++) {
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

    bool MostrarPuntoDeSalud(float vida, int numPunto) {
        //para mostrar la salud
        return (numPunto >= vida);
    }

    bool MostrarPuntoDeStamina(int stamina, int numPunto) {
        return ((numPunto * 10) >= stamina);
    }

    void ColoresTexto(float vida, int stamina) {

        switch (vida) {

            case 1:
                vidaText.color = color1;
                break;
            case 2:
                vidaText.color = color2;
                break;
            case 3:
                vidaText.color = color3;
                break;
            case 4:
                vidaText.color = color4;
                break;
            case 5:
                vidaText.color = color5;
                break;
            case 6:
                vidaText.color = color6;
                break;
            case 7:
                vidaText.color = color7;
                break;
            case 8:
                vidaText.color = color8;
                break;
            default:
                break;
        }

    }

 
}
