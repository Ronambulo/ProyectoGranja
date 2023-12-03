using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Music : MonoBehaviour
{
    [Header("----------- Instancee -----------")]
    public static Music instance;

    [Header("----------- Audio Source -----------")]
    public AudioSource musicTitle;
    public AudioSource musicFarm;
    public AudioSource musicDeath;
    public AudioSource musicMazmorra;
    public AudioSource musicBarrera; 
    public AudioSource musicHome;

    [Header ("----------- Confi Player -----------")]
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

        // asefurar que solo haya una instancia de Music
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // No destruyas este objeto al cargar una nueva escena
        }
        else
        {
            Destroy(gameObject); // Ya existe una instancia, destruye esta
            return;
        }

        StopAllMusic();
        PlayDefaultMusic(); // Iniciar la música predeterminada al principio

    }


    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        ThisScene = scene.name;

        // Seleccionar y reproducir la música según la escena actual
         PlayMusicForScene(ThisScene);
    }

    void PlayMusicForScene(string sceneName)
    {
        switch (sceneName)
        {
            case "TitleScreen":
                StopAllMusicExcept(musicTitle);
                PlayMusic(musicTitle);
                break;
            case "EscenaGranja":
            case "EscenaPueblo":
            case "EscenaCamino":
                StopAllMusicExcept(musicFarm);
                PlayMusic(musicFarm);
                break;
            case "EscenaCasaPlayer":
                StopAllMusicExcept(musicHome);
                PlayMusic(musicHome);
                break;
            case "EscenaMazmorraDentro":
                StopAllMusicExcept(musicMazmorra);
                PlayMusic(musicMazmorra);
                break;
            case "EscenaMazmorraFuera":
                StopAllMusicExcept(musicBarrera);
                PlayMusic(musicBarrera);
                break;
            default:
                StopAllMusicExcept(musicTitle);
                PlayDefaultMusic(); // Reproducir música predeterminada si no coincide con ninguna escena específica
                break;
        }
    }

    void PlayDefaultMusic()
    {
        // Puedes ajustar esto para que coincida con la música que quieras reproducir al principio
        PlayMusic(musicTitle);
    }

    void PlayMusic(AudioSource audioSource)
    {
        if (!audioSource.isPlaying)
        {
            audioSource.Play();
        }
    }

    void StopAllMusicExcept(AudioSource exceptionSource)
    {
        if (musicTitle != exceptionSource) musicTitle.Stop();
        if (musicFarm != exceptionSource) musicFarm.Stop();
        if (musicDeath != exceptionSource) musicDeath.Stop();
        if (musicMazmorra != exceptionSource) musicMazmorra.Stop();
        if (musicBarrera != exceptionSource) musicBarrera.Stop();
        if (musicHome != exceptionSource) musicHome.Stop();
    }

    void StopAllMusic()
    {
        musicTitle.Stop();
        musicFarm.Stop();
        musicDeath.Stop();
        musicMazmorra.Stop();
        musicBarrera.Stop();
        musicHome.Stop();
    }

}
