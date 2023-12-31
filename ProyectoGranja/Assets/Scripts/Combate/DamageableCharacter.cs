using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//A�adimos nuestra interfaz creada
public class DamageableCharacter : MonoBehaviour, IDamageable
{
    Animator animator;
    Rigidbody2D rb;
    Collider2D physicsCollider;

    //Para m�s adelante decidir si queremos desactivar las f�sicas
    public bool disableSimulation = false;

    public float vida = 8f;
    //Para que un objeto sea targeteable (objetivo)
    public bool targeteable = true;

    public ZonaDeteccion zonaDeteccion;



    public float VidaCharacter
    {
        //Encapsulamos variables en una clase y proporcionamos un control m�s preciso (es un setter)
        set
        {
            if (value < vida)
            {
                animator.SetTrigger("hit");
            }


            //asignamos nuevo valor a la variable (value es un valor que le daremos m�s adelante)
            vida = value;

            if (vida <= 0)
            {
                animator.SetBool("isAlive", false);
                //Ya no ser� targeteable
                this.Targeteable = false;
                vida = 0;
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
            //determninar� si el objeto que es targeteable est� activo o no
            targeteable = value;

            physicsCollider.enabled = false;
        }
    }



    public void Start()
    {
        animator = GetComponent<Animator>();

        // Para estar seguros de que est� vivo desde el principio
        animator.SetBool("isAlive", true);

        rb = GetComponent<Rigidbody2D>();
        physicsCollider = GetComponent<Collider2D>();
    }


    // //Te lo a�ade autom�ticamente el programa cuando a�ades la interfaz
    public void OnHit(float danio, Vector2 knockback)
    {
        VidaCharacter -= danio;
        //Aplicar fuerza al enemigo
        transform.Translate(knockback * Time.deltaTime);
    }

    public void OnHit(float danio)
    {
        VidaCharacter -= danio;
    }

    public void ObjectDestroy()
    {
        zonaDeteccion.dineroObject.dinero += 5;
        Destroy(gameObject);
    }
    
}
