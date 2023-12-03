using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Dialogue : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textoDialogo;
    [SerializeField] private int numFrases;
    [SerializeField] private string[] frasesDialogo;
    [SerializeField] private bool playerInDialo;
    [SerializeField] private GameObject DialoWindow;
    [SerializeField] private GameObject ToolBar;
    [SerializeField] private int index;

    void Awake()
    {
        textoDialogo.text = "";
        DialoWindow = GameObject.FindWithTag("VentanaDialogo");
        ToolBar = GameObject.FindWithTag("ToolBar");
        index = 0;
        DialoWindow.SetActive(false);
    }


   // Update is called once per frame
    void Update()
    {
        if(DialoWindow == null){
            DialoWindow = GameObject.FindWithTag("VentanaDialogo");
            ToolBar = GameObject.FindWithTag("ToolBar");
        }

        if (Input.GetKeyDown("f") && playerInDialo) {
            ToolBar.SetActive(false);
            DialoWindow.SetActive(true);
            StartDialogue();
            while (index < numFrases) {
                if (Input.GetKeyDown("f")) {
                    Debug.Log("next luine");
                    NextLine();
                } else {
                        
                }
                StopAllCoroutines();
                textoDialogo.text = frasesDialogo[index];
                ToolBar.SetActive(true);
                DialoWindow.SetActive(false);
            }
        }
    }
       
    void StartDialogue() {
        StopAllCoroutines();
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine() {
        textoDialogo.text = frasesDialogo[index];
        return null;
    }

    void NextLine() {
        if (index < numFrases-1) {
            index++;
            textoDialogo.text = "";
            StopAllCoroutines();
            StartCoroutine(TypeLine());
        } else {
            DialoWindow.SetActive(false);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInDialo = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if (other.CompareTag("Player"))
        {
            playerInDialo = false;
            DialoWindow.SetActive(false);
            ToolBar.SetActive(true);
        }
    }
}
