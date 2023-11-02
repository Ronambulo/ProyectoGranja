using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SequenceAnimator : MonoBehaviour
{
    //Creo lista
    List<Animator> _animators;
    public float tiempoIntermedio = 0.15f;
    public float tiempoAcabado = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        //Inicializamos la lista con todos los componentes Animator
        _animators = new List<Animator>(GetComponentsInChildren<Animator>());

        //Inicializa la secuencia de la animación
        StartCoroutine(DoAnimation());
    }

    // PARA LOOPEAR PARA SIEMPRE - IEnumerator, para realizar operaciones asincrónicas ( no simultáneo, no coincidente)
    IEnumerator DoAnimation()
    {
        while (true)
        {
            //Itera a través de todos los componentes Animator en la lista _animators
            foreach (var animator in _animators)
            {
                //activa el triger DoAnimation, dentro de Animator
                animator.SetTrigger("DoAnimation");

                //Hace que el programa espere durante un período de tiempo especificado
                yield return new WaitForSeconds(tiempoIntermedio); 
            }
                //creamos un delay para que cuando llegue al final, se espere un poco hasta volver a empezar
                yield return new WaitForSeconds(tiempoAcabado);
        }
    }

    
}
