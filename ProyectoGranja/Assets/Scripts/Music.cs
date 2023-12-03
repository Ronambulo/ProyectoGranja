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

    public string ThisScene;

    /*[Header("----------- Audio Clip -----------")]
    public AudioClip background;
    public AudioClip title;
    public AudioClip death;
    public AudioClip mazmorra;*/

    // Start is called before the first frame update
    void Start()
    {
        musicTitle.Stop();
        musicFarm.Stop();
        musicDeath.Stop();
        musicMazmorra.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
