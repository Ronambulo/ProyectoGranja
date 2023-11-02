using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class OnHoverScript : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private Animator animator;
    public bool enter = false;

    private void Update()
    {
        animator = GetComponent<Animator>();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        animator.SetBool("OnHoverBool", true);
        enter = true;
}

    public void OnPointerExit(PointerEventData eventData)
    {
        animator.SetBool("OnHoverBool", false);
        enter = false;
    }
}
