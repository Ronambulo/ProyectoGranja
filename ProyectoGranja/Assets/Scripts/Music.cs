using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Music : MonoBehaviour
{
    [Header("----------- Audio Source -----------")]
    public AudioSource musicTitle;
    public AudioSource musicFarm;
    public AudioSource musicDeath;
    public AudioSource musicMazmorra;
    public AudioSource musicBarrera; 
    public AudioSource musicHome;

    public string ThisScene; 
    public Transform player;

    /*[Header("----------- Audio Clip -----------")]
    public AudioClip background;
    public AudioClip title;
    public AudioClip death;
    public AudioClip mazmorra;*/

    // Start is called before the first frame update
    void Start()
    {
        SceneManager.sceneLoaded += OnSceneLoaded; // Suscribirse al evento
        PlayDefaultMusic(); // Iniciar la música predeterminada al principio

    }


    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        ThisScene = scene.name;

        // Detener todas las músicas al principio
        StopAllMusic();

        // Seleccionar y reproducir la música según la escena actual
       PlayMusicForScene(ThisScene);
    }

   void PlayMusicForScene(string sceneName)
    {

        switch (sceneName)
        {
            case "TitleScreen":
                musicTitle.Play();
                musicFarm.Stop();
                musicDeath.Stop();
                musicBarrera.Stop();
                musicMazmorra.Stop();
                musicHome.Stop();
                break;
            case "EscenaGranja":
                musicTitle.Stop();
                musicFarm.Play();
                musicDeath.Stop();
                musicBarrera.Stop();
                musicMazmorra.Stop();
                musicHome.Stop();
                break;
            case "EscenaCasaPlayer":
                musicTitle.Stop();
                musicFarm.Stop();
                musicDeath.Stop();
                musicBarrera.Stop();
                musicMazmorra.Stop();
                musicHome.Play();
                break;
            case "EscenaMazmorraDentro":
                musicTitle.Stop();
                musicFarm.Stop();
                musicDeath.Stop();
                musicBarrera.Stop();
                musicMazmorra.Play();
                musicHome.Stop();
                break;

            case "EscenaMazmorraFuera":
                musicTitle.Stop();
                musicFarm.Stop();
                musicDeath.Stop();
                musicBarrera.Play();
                musicMazmorra.Stop();
                musicHome.Stop();
                break;

            default:
                PlayDefaultMusic(); // Reproducir música predeterminada si no coincide con ninguna escena específica
                break;
        }
    }

    void StopAllMusic()
    {
        musicTitle.Stop();
        musicFarm.Stop();
        musicDeath.Stop();
        musicMazmorra.Stop();
        musicHome.Stop();
    }

    void PlayDefaultMusic()
    {
        // Puedes ajustar esto para que coincida con la música que quieras reproducir al principio
        musicTitle.Play();
        musicFarm.Stop();
        musicDeath.Stop();
        musicMazmorra.Stop();
        musicBarrera.Stop();
        musicHome.Stop();
    }

    // Update is called once per frame
    void Update()
    {
 
        

    }
}
