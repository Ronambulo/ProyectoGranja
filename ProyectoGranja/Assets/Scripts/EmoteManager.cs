using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmoteManager : MonoBehaviour
{

    [SerializeField] public bool interact = false;
    void Update()
    {
        Animator animator = GetComponent<Animator>();

        if (Input.GetKeyDown(KeyCode.G)) { animator.SetBool("G", true); }
        else { animator.SetBool("G", false); }

        if (Input.GetKeyDown(KeyCode.H)) { animator.SetBool("H", true); }
        else { animator.SetBool("H", false); }

        if (Input.GetKeyDown(KeyCode.J)) { animator.SetBool("J", true); }
        else { animator.SetBool("J", false); }

        if (Input.GetKeyDown(KeyCode.K)) { animator.SetBool("K", true); }
        else { animator.SetBool("K", false); }

        if(interact == true){ animator.SetBool("Interact", true); }
        else { animator.SetBool("Interact", false); }

    }
}
