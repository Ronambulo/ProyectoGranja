using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Vector2 minXYLimits = new Vector2(-6.66f, -5.98f); // L�mites m�nimos en X y Z
    public Vector2 maxXYLimits = new Vector2(0.15f, 0); // L�mites m�ximos en X y Z
    public float smoothSpeed = 0.125f; // Velocidad de suavizado del movimiento de la c�mara
    public float prueba;
    public Transform target;
    private void Start()
    {
        
    }

    void FixedUpdate()
        {
        if(target == null)
        {
            target = GameObject.FindWithTag("Player").transform;
        }
        
        if ((target) == null)
                return; // Asegurarse de que hay un objetivo para seguir

            // Solo ajusta la posici�n en el eje X y Z, manten el valor de Y de la camara
            Vector3 desiredPosition = new Vector3(
                Mathf.Clamp(target.position.x, minXYLimits.x, maxXYLimits.x),
                Mathf.Clamp(target.position.y, minXYLimits.y, maxXYLimits.y),
                -10f
            );
            
            prueba = target.position.y;
            // Aplicar suavizado al movimiento de la camara
            transform.position = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        }
}

