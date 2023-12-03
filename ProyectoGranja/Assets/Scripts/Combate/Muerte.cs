using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Muerte : MonoBehaviour
{
    public GameObject panelMuerte;
    public GameObject player;
    public Transform transformPlayer;

    Animator animator;

    public DamageableCharacter playerHealth;
    public PlayerController playerStamina;
    public DineroScript playerDinero;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void AparicionPanelMuerte()
    {
        panelMuerte.SetActive(true);
        Time.timeScale = 0;
    }

    public void Vuelta(string vueltaACasa)
    {
        //REAPARECEMOS EN LA CASA
        panelMuerte.SetActive(false);
        SceneManager.LoadScene(vueltaACasa);
        Time.timeScale = 1f;

        //REINICIAMOS SUS STATS
        playerHealth.VidaCharacter = 8f;
        playerStamina.StaminaCharacter = 80;
        playerDinero.dineroCaracter = playerDinero.dineroCaracter/2;

        //VOLVEMOS AL IDLE
        animator.SetBool("isAlive", true);

        //reseteamos posici�n del Player
        transformPlayer.position = new Vector3(1.88f, -1.7f, -0.01f);
    }

}
