using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SequenceAnimator : MonoBehaviour
{
    List<Animator> _animators;
    public float tiempoIntermedio = 0.15f;
    public float tiempoAcabado = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        _animators = new List<Animator>(GetComponentsInChildren<Animator>());
        StartCoroutine(DoAnimation());
    }

    // PARA LOOPEAR PARA SIEMPRE
    IEnumerator DoAnimation()
    {
        while (true)
        {
            foreach (var animator in _animators)
            {
                animator.SetTrigger("DoAnimation");
                yield return new WaitForSeconds(tiempoIntermedio); // "WaitForseconds" estaba mal escrito, debe ser "WaitForSeconds"
            }
                //creamos un delay para que cuando llegue al final, se espere un poco hasta volver a empezar
                yield return new WaitForSeconds(tiempoAcabado);
        }
    }

    
}
