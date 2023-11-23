using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordHitBox : MonoBehaviour
{
    public float swordDamage = 1f;

    public Collider2D swordCollider;

   void Start(){
        swordCollider.GetComponent<Collider2D>();
   }


   //
   void SeDa(Collider2D collider){
        //Cuando se da, nos llega este mensaje
        collider.SendMessage("OnHIt", swordDamage);
   }
}