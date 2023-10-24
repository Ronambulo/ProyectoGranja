using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DontDestroyOnLoad : MonoBehaviour
{

    private static DontDestroyOnLoad instance;



    private void Awake()
    {
        
        // Comprueba si ya hay una instancia existente.
        if (instance == null)
        {
            // Si no hay instancia existente, esta ser� la instancia actual.
            instance = this;

            DontDestroyOnLoad(gameObject); // No se destruir� al cargar una nueva escena.
        }
        else
        {
            // Si ya existe una instancia, destruye este objeto duplicado.
            Destroy(gameObject);
        }

    }
}
