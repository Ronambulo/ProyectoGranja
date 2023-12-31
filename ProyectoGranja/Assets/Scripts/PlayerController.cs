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

    private bool ataque;
    public int stamina = 80;

    private float timeSinceLastMovement;
    public int timeBetweenStaminaLoss = 10;

    //CONFIGURACIÓN ESPADA
    public GameObject swordHitbox;
    Collider2D swordCollider;
    public ToolBar_UI espadas;


    //Colisiones con objetos
    Vector2 movementInput;

     //Getter y setter de stamina para utilizarlo para el UI de stamina
    public int StaminaCharacter
    {
        set
        {
            stamina = value;
        }
        get
        {
            return stamina;
        }

    }


    void Start(){
        //Inicializamos collider de la espada con el objeto
        swordCollider = swordHitbox.GetComponent<Collider2D>();
    }

    void FixedUpdate()
    {
        swordCollider = swordHitbox.GetComponent<Collider2D>();
        Animator animator = GetComponent<Animator>();

        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
        //Dentro de los Inputs, el String Jump pertenece al espacio
        ataque = Input.GetButton("Jump");

        prueba = horizontal;
        Animaciones(horizontal, vertical, animator);

        Vector3 direction = new Vector3(horizontal, vertical);
        direction.Normalize();
        transform.Translate(direction * speed);

        interiorTPObject = transform.Find("Emotes").gameObject;

        //Como hemos cambiado el personaje de dinámico a Kynetic (como se escriba), hay que hacer que manualmente colisione con las cosas
       /* if (movementInput != Vector2.zero)
        {
            bool success = TryMove(movementInput);

            if (!success)
            {

                success = TryMove(new Vector2(movementInput.x, 0));

                if (!success)
                {

                    success = TryMove(new Vector2(0, movementInput.y));

                }

            }
        }
       private bool TryMove(Vector2 direction);
        void OnMove(){

            movementInput = movementValue.Get<Vector2>();
        }*/

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
        
        if(ataque && espadas.nombreSeccionado == "Iron Sword")
        {
            //Debug.Log("Le estas dando");
            animator.SetBool("Attack", true);
        }
        else{
            //Debug.Log("NO le estas dando");
            animator.SetBool("Attack", false);
        }

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("InteriorTP") || other.CompareTag("NPC") || other.CompareTag("NPCFlores"))
        {
            emoteManager = interiorTPObject.GetComponent<EmoteManager>();
            emoteManager.interact = true;
            if(other.CompareTag("NPCFlores") && Input.GetKey("e")){
                
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

    
