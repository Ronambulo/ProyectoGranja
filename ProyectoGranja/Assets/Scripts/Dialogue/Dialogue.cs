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

    public float wordSpeed;
    public bool playerIsClose;


    void Start()
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
            else if (dialogueText.text == dialogue[index])
            {
                NextLine();
            }

        }
        if (Input.GetKeyDown(KeyCode.Q) && dialoguePanel.activeInHierarchy)
        {
            RemoveText();
        }
    }
       
    void StartDialogue() {
        StopAllCoroutines();
        StartCoroutine(TypeLine());
    }

    IEnumerator Typing()
    {
        foreach(char letter in dialogue[index].ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(wordSpeed);
        }
    }

    public void NextLine()
    {
        if (index < dialogue.Length - 1)
        {
            index++;
            textoDialogo.text = "";
            StopAllCoroutines();
            StartCoroutine(TypeLine());
        } else {
            DialoWindow.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerIsClose = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInDialo = false;
            DialoWindow.SetActive(false);
            ToolBar.SetActive(true);
        }
    }
}