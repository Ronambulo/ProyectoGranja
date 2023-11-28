using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Añadimos nuestra interfaz creada
public class DamageableCharacter : MonoBehaviour, IDamageable
{
    Animator animator;
    Rigidbody2D rb;
    Collider2D physicsCollider;

    //Para más adelante decidir si queremos desactivar las físicas
    public bool disableSimulation = false;

    public float vida = 10f;
    //Para que un objeto sea targeteable (objetivo)
    public bool targeteable = true;


    public float VidaCharacter
    {
        //Encapsulamos variables en una clase y proporcionamos un control más preciso (es un setter)
        set
        {
            //Implica que el valor será menor, entonces realiza la animación del hit
            if (value < vida)
            {
                animator.SetTrigger("hit");
            }

            //asignamos nuevo valor a la variable (value es un valor que le daremos más adelante)
            vida = value;

            if (vida <= 0)
            {
                animator.SetBool("isAlive", false);
                //Ya no será targeteable
                this.Targeteable = false;
            }
        }
        //GETTER
        get
        {
            return vida;
        }
    }

    //Getter y setter de targeteable (ser un objetivo)
    public bool Targeteable
    {
        get { 
            return targeteable; 
        }
        set
        {
            //determninará si el objeto que es targeteable está activo o no
            targeteable = value;

            //Cuando desactivamos targeteable, Queremos descativar la simulación de las físicas (osea desactivar el sistema de físicas), aunque no queremos 
            // que siempre se desactive, por eso creamos disableSimulation y ponemos condición
            //NO SE POR QUÉ NO ME FUNCIONA!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!-----------------------------------------
            if (disableSimulation && !targeteable ){
                Debug.Log("DESACTIVADO");
                rb.simulated = false;
            }
            else {
                rb.simulated = true;
            }

            physicsCollider.enabled = false;
        }
    }



    public void Start()
    {
        animator = GetComponent<Animator>();

        // Para estar seguros de que está vivo desde el principio
        animator.SetBool("isAlive", true);

        rb = GetComponent<Rigidbody2D>();
        physicsCollider = GetComponent<Collider2D>();
    }


    // //Te lo añade automáticamente el programa cuando añades la interfaz
    public void OnHit(float danio, Vector2 knockback)
    {
        Debug.Log("Le ha dado con " + danio + " de daño.");
        VidaCharacter -= danio;

        //Aplicar fuerza al enemigo
        rb.AddForce(knockback);
    }

    public void OnHit(float danio)
    {
        Debug.Log("Le ha dado con " + danio + " de daño.");

        VidaCharacter -= danio;
    }

    public void ObjectDestroy()
    {
        Destroy(gameObject);
    }

    
}
