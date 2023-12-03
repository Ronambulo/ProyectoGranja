using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZonaDeteccion : MonoBehaviour
{
    public string tagObjetivo = "Player";

    //Lista de las colisiones que detecta
    public List<Collider2D> objetosDetectado = new List<Collider2D>();

    public Collider2D col;
    public DineroScript dineroObject;


    //Detecta cuando el enemigo entra en el rango
    void OnTriggerEnter2D(Collider2D collider) {
        
        //si el tag es el del jugador
        if (collider.gameObject.tag == tagObjetivo){
            objetosDetectado.Add(collider);
        }

        if(collider.CompareTag("Player")){
            dineroObject = collider.GetComponent<DineroScript>();
        }
    }

    //Detecta cuando el enemigo sale del rango
    void OnTriggerExit2D(Collider2D collider)
    {
        //si el tag es el del jugador
        if (collider.gameObject.tag == tagObjetivo)
        {
            objetosDetectado.Remove(collider);
        }
    }
}




