using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{

    public float speed;
    public float prueba;
    
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
            }
            else if (horizontal > 0)
            {
                transform.localScale = new Vector3(1, 1, 0);
            }
        }
        else
        {
            animator.SetBool("Walking", false);
        }
    }

}
