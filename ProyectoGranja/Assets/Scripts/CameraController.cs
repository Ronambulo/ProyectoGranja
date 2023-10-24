using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Vector2 minXZLimits = new Vector2(-6.66f, -5.98f); // Límites mínimos en X y Z
    public Vector2 maxXZLimits = new Vector2(0.15f, 0); // Límites máximos en X y Z
    public float smoothSpeed = 0.125f; // Velocidad de suavizado del movimiento de la cámara
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

            // Solo ajusta la posición en el eje X y Z, mantén el valor de Y de la cámara
            Vector3 desiredPosition = new Vector3(
                Mathf.Clamp(target.position.x, minXZLimits.x, maxXZLimits.x),
                Mathf.Clamp(target.position.y, minXZLimits.y, maxXZLimits.y),
                -10f
            );

            prueba = target.position.y;
            // Aplicar suavizado al movimiento de la cámara
            transform.position = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        }
}

