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
    private int index;

    void Awake()
    {
        textoDialogo.text = string.Empty;
        DialoWindow = GameObject.FindWithTag("VentanaDialogo");
        ToolBar = GameObject.FindWithTag("ToolBar");
        DialoWindow.GetComponent<Image>().enabled = false;
    }


   // Update is called once per frame
    void Update()
    {
        if(DialoWindow == null){
            DialoWindow = GameObject.FindWithTag("VentanaDialogo");
            ToolBar = GameObject.FindWithTag("ToolBar");
        }

        if (Input.GetKey("f") && playerInDialo) {
            ToolBar.SetActive(false);
            DialoWindow.GetComponent<Image>().enabled = true;
            DialoWindow.SetActive(true);
            StartDialogue();
            while (index < numFrases) {
                if (Input.GetKey("e")) {
                    NextLine();
                } else {
                        
                }
                StopAllCoroutines();
                textoDialogo.text = frasesDialogo[index];
                ToolBar.SetActive(true);
                DialoWindow.GetComponent<Image>().enabled = false;
                 DialoWindow.SetActive(false);
            }
        }
    }
       
    void StartDialogue() {
        index = 0;
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine() {
        textoDialogo.text = frasesDialogo[index];
        return null;
    }

    void NextLine() {
        if (index < numFrases-1) {
            index++;
            textoDialogo.text = string.Empty;
            StartCoroutine(TypeLine());
        } else {
            gameObject.SetActive(false);
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
        }
    }
}
