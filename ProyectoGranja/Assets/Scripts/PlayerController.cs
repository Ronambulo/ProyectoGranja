using System;
using System.Collections;
using System.Collections.Generic;
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



    // Update is called once per frame
    void FixedUpdate()
    {
        Animator animator = GetComponent<Animator>();

        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");


        prueba = horizontal;
        Animaciones(horizontal, vertical, animator);
        
        Vector3 direction = new Vector3(horizontal, vertical);
        direction.Normalize();
        transform.Translate(direction * speed);

        interiorTPObject = transform.Find("Emotes").gameObject;
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
        if (other.CompareTag("InteriorTP"))
        {
            emoteManager = interiorTPObject.GetComponent<EmoteManager>();
            emoteManager.interact = true;
        }
            emoteManager.interact = true;
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        emoteManager = interiorTPObject.GetComponent<EmoteManager>();
        emoteManager.interact = false;
    }

    public static implicit operator PlayerController(DontDestroyOnLoad v)
    {
        throw new NotImplementedException();
    }
}
