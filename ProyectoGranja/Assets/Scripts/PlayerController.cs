using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float prueba;
    public float valor = 10f;
    private EmoteManager emoteManager;
    public GameObject interiorTPObject;
    private float horizontal;
    private float vertical;

    public int vida = 100;
    public int stamina = 100;

    private float timeSinceLastMovement;
    public int timeBetweenStaminaLoss = 10;

    void FixedUpdate()
    {
        Animator animator = GetComponent<Animator>();

        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");


        prueba = horizontal;
        Animaciones(horizontal, vertical, animator);
        
        Vector3 direction = new Vector3(horizontal, vertical);
        direction.Normalize();
        transform.Translate(direction * speed);

        interiorTPObject = transform.Find("Emotes").gameObject;



        //PERDIDA DE STAMINA EL PARAMETRO ES LA CANTIDAD DE ESTAMINA QUE SE PIERDE
        perididaStamina(1);

    }

    void Animaciones(float horizontal, float vertical, Animator animator)
    {
        if (vertical > 0 && horizontal == 0)
        {
            animator.SetBool("WalkingUp", true);
        }
        else
        {
            animator.SetBool("WalkingUp", false);
        }
        if (vertical < 0 && horizontal == 0) 
        {
            animator.SetBool("WalkingDown", true);
        }
        else 
        {
            animator.SetBool("WalkingDown", false);
        }
        if (horizontal != 0)
        {
            animator.SetBool("Walking", true);
            if (horizontal < 0)
            {
                transform.localScale = new Vector3(-1, 1, 0);
                interiorTPObject.transform.localScale = new Vector3(-1, 1, 0);
            }
            else if (horizontal > 0)
            {
                transform.localScale = new Vector3(1, 1, 0);
                interiorTPObject.transform.localScale = new Vector3(1, 1, 0);
            }
        }
        else
        {
            animator.SetBool("Walking", false);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("InteriorTP") || other.CompareTag("NPC"))
        {
            emoteManager = interiorTPObject.GetComponent<EmoteManager>();
            emoteManager.interact = true;
            if(other.CompareTag("NPC")){
            }
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        emoteManager = interiorTPObject.GetComponent<EmoteManager>();
        emoteManager.interact = false;
    }

    public static implicit operator PlayerController(DontDestroyOnLoad v)
    {
        throw new NotImplementedException();
    }


    void perididaStamina(int staminaLossAmount)
    {
        if (vertical != 0 || horizontal != 0)
        {
            timeSinceLastMovement += Time.deltaTime;

            // Verifica si ha pasado el tiempo necesario para perder stamina.
            if (timeSinceLastMovement >= timeBetweenStaminaLoss)
            {
                // Reduce la stamina y reinicia el tiempo transcurrido.
                stamina -= staminaLossAmount;
                timeSinceLastMovement = 0.0f;
            }
        }



    }
}

    
