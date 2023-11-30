using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    //Lista que contiene las frases
        /*El objeto Queue funciona de manera similar a una cola FIFO, lo que permite ir leyendo sus elementos en orden en el que fueron
        cargados sin tener que procuparse por posiciones como en un array*/
    private Queue<string> frases; 
    [SerializeField] TextMeshProUGUI nombreDialogo;
    [SerializeField] TextMeshProUGUI textoDialogo;
    
    // Start is called before the first frame update
    void Start()
    {
        frases = new Queue<string>();
    }

    public void StartDialogue(Dialogue dialogue) {
        Debug.Log("FUNCIONANDO DIALOGO");
        nombreDialogo.text = dialogue.nombreNPC;

        frases.Clear();

        foreach (string frase in dialogue.frases){
            frases.Enqueue(frase);
        }

        displayNextSentence();
    }

    public void displayNextSentence() {
        if (frases.Count == 0) {
            endDialogue();
            return;
        }
        
        string frase = frases.Dequeue();
        textoDialogo.text = frase;

    }

    public void endDialogue() {
        Debug.Log("FIN DIALOGO");
    }

    // Update is called once per frame
    void Update()
    {
        
    }


}
