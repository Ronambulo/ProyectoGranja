using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Dialogue : MonoBehaviour
{
<<<<<<< Updated upstream
    [SerializeField] private TextMeshProUGUI textoDialogo;
    [SerializeField] private int numFrases;
    [SerializeField] private string[] frasesDialogo;
    [SerializeField] private bool playerInDialo;
    [SerializeField] private GameObject DialoWindow;
    [SerializeField] private GameObject ToolBar;
    private int index;
=======
    public GameObject dialoguePanel;
    
    public TextMeshProUGUI dialogueText;
    public string[] dialogue;
    private int index = 0;
>>>>>>> Stashed changes

    public float wordSpeed;
    public bool playerIsClose;


    void Start()
    {
<<<<<<< Updated upstream
        textoDialogo.text = string.Empty;
        DialoWindow = GameObject.FindWithTag("VentanaDialogo");
        ToolBar = GameObject.FindWithTag("ToolBar");
        DialoWindow.GetComponent<Image>().enabled = false;
=======
        dialogueText.text = "";
        RemoveText();
>>>>>>> Stashed changes
    }

    // Update is called once per frame
    void Update()
    {
<<<<<<< Updated upstream
        if(DialoWindow == null){
            DialoWindow = GameObject.FindWithTag("VentanaDialogo");
            ToolBar = GameObject.FindWithTag("ToolBar");
        }

        if (Input.GetKey("e") && playerInDialo) {
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
=======
        if (Input.GetKeyDown(KeyCode.E) && playerIsClose)
        {
            if (!dialoguePanel.activeInHierarchy)
            {
                dialoguePanel.SetActive(true);
                StartCoroutine(Typing());
>>>>>>> Stashed changes
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
<<<<<<< Updated upstream
       
    void StartDialogue() {
        index = 0;
        StartCoroutine(TypeLine());
=======

    public void RemoveText()
    {
        dialogueText.text = "";
        index = 0;
        dialoguePanel.SetActive(false);
>>>>>>> Stashed changes
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
<<<<<<< Updated upstream
            textoDialogo.text = string.Empty;
            StartCoroutine(TypeLine());
        } else {
            gameObject.SetActive(false);
=======
            dialogueText.text = "";
            StartCoroutine(Typing());
        }
        else
        {
            RemoveText();
>>>>>>> Stashed changes
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
<<<<<<< Updated upstream
            playerInDialo = false;
=======
            playerIsClose = false;
            RemoveText();
>>>>>>> Stashed changes
        }
    }
}