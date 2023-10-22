using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{

    public float speed;
    
    // Update is called once per frame
    void FixedUpdate()
    {
        Animator animator = GetComponent<Animator>();

        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        Animaciones(horizontal, vertical, animator);
        
        Vector3 direction = new Vector3(horizontal, vertical);

        transform.Translate(direction * speed);
    }

    void Animaciones(float horizontal, float vertical, Animator animator)
    {
        if (horizontal != 0 || vertical != 0)
        {
            animator.SetBool("Walking", true);
            if(horizontal < 0)
            {
                transform.localScale = new Vector3(-1 , 1, 0);
            }
            else if(horizontal > 0)
            {
                transform.localScale = new Vector3(1, 1, 0);
            }
        }else
        {
            animator.SetBool("Walking", false);
        }
    }

}
