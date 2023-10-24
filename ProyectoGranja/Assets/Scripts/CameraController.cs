using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Vector2 minXZLimits = new Vector2(-6.66f, -5.98f); // L�mites m�nimos en X y Z
    public Vector2 maxXZLimits = new Vector2(0.15f, 0); // L�mites m�ximos en X y Z
    public float smoothSpeed = 0.125f; // Velocidad de suavizado del movimiento de la c�mara
    public float prueba;
    public Transform target;

    private void Start()
    {
       target = GameObject.FindWithTag("Player").transform;
    }

    void FixedUpdate()
        {
            
            if ((target) == null)
                return; // Asegurarse de que hay un objetivo para seguir

            // Solo ajusta la posici�n en el eje X y Z, mant�n el valor de Y de la c�mara
            Vector3 desiredPosition = new Vector3(
                Mathf.Clamp(target.position.x, minXZLimits.x, maxXZLimits.x),
                Mathf.Clamp(target.position.y, minXZLimits.y, maxXZLimits.y),
                -10f
            );

            prueba = target.position.y;
            // Aplicar suavizado al movimiento de la c�mara
            transform.position = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        }
}

