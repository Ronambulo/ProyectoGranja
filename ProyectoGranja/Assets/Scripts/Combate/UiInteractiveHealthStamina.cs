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
        //muertePanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        vida = playerHealth.VidaCharacter;
        stamina = playerStamina.StaminaCharacter;

        vidaText.text = "" + vida;
        //vidaText.color =  color2; 

        staminaText.text = "" + stamina;

        RellenaVida();
        RellenaStamina();
        ColoresTexto(vida, stamina);


        //Por si se rebasa la vida del jugador de la vida máxima
        if (vida > vidaMax) {
            vida = vidaMax;
        }
        else if(vida <= 0)
        {
            panelMuerte();
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

            case 1f:
                vidaText.color = color1;
                break;
            case 2f:
                vidaText.color = color2;
                break;
            case 3f:
                vidaText.color = color3;
                break;
            case 4f:
                vidaText.color = color4;
                break;
            case 5f:
                vidaText.color = color5;
                break;
            case 6f:
                vidaText.color = color6;
                break;
            case 7f:
                vidaText.color = color7;
                break;
            case 8f:
                vidaText.color = color8;
                break;
            default:
                break;
        }


        if (stamina >= 70 || stamina <= 80) {
            staminaText.color = color8;
        }
        else if (stamina >= 60 || stamina < 70)
        {
            staminaText.color = color7;
        }
        else if (stamina >= 50 || stamina < 60)
        {
            staminaText.color = color6;
        }
        else if (stamina >= 40 || stamina < 50) {
            staminaText.color = color5;
        }
        else if (stamina >= 30 || stamina < 40) {
            staminaText.color = color4;
        }
        else if (stamina >= 20 || stamina < 30)
        {
            staminaText.color = color3;
        }
        else if (stamina >= 10 || stamina < 20) {
            staminaText.color = color2;
        }
        else if (stamina >= 0 || stamina < 10) {
            staminaText.color = color1;
        }
    }

    private void panelMuerte() {

        muertePanel.SetActive(true);
        Time.timeScale = 0;
    }
}
