using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordHitBox : MonoBehaviour
{
     public float swordDamage = 1f;
     public bool si = false;

     public Collider2D swordCollider;

     void Start(){
          if(swordCollider == null){
               Debug.LogWarning("El Collider de la espada no está establecido.");
          }
     }

     //Busca una física del enemigo (su Rigidbody) y manda on hit daño al gameObject
     void OnCollisionEnter2D(Collision2D colision){
    
          colision.collider.SendMessage("OnHit", swordDamage);
  
     }

 
}