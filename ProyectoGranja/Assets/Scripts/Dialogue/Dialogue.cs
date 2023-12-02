using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Dialogue : MonoBehaviour
{
    public TextMeshProUGUI textoDialogo;
    public int numFrases;
    public string[] frasesDialogo;
    public float velocidadMostrar;
    private int index;

    // Start is called before the first frame update
    void Start()
    {
        textoDialogo.text = string.Empty;
        StartDialogue();
    }


   // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("e")) {
            if (textoDialogo.text == frasesDialogo[index]) {
                NextLine();
            } else {
                StopAllCoroutines();
                textoDialogo.text = frasesDialogo[index];
            }
        }
    }

    void StartDialogue() {
        index = 0;
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine() {
        foreach(char c in frasesDialogo[index].ToCharArray()) {
            textoDialogo.text += c;
            yield return new WaitForSeconds(velocidadMostrar);
        }
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
}
