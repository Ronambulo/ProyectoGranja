using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Añadimos nuestra interfaz creada
public class DamageableCharacter : MonoBehaviour, IDamageable
{
    Animator animator;
    Rigidbody2D rb;
    public bool targeteable = true;

    public float VidaEnemigo
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
            }
        }
        //GETTER
        get
        {
            return vida;
        }
    }

    public float vida = 10f;

    public void Start()
    {
        animator = GetComponent<Animator>();

        // Para estar seguros de que está vivo desde el principio
        animator.SetBool("isAlive", true);

        rb = GetComponent<Rigidbody2D>();
    }


    // //Te lo añade automáticamente el programa cuando añades la interfaz
    public void OnHit(float danio, Vector2 knockback)
    {
        Debug.Log("Le ha dado al SLIME con " + danio + " de daño.");
        VidaEnemigo -= danio;

        //Aplicar fuerza al enemigo
        rb.AddForce(knockback);
    }

    public void OnHit(float danio)
    {
        Debug.Log("Le ha dado al SLIME con " + danio + " de daño.");

        VidaEnemigo -= danio;
    }

    public void ObjectDestroy()
    {
        Destroy(gameObject);
    }

    
}
