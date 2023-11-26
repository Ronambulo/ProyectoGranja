using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordHitBox : MonoBehaviour
{
     public float swordDamage = 1f;
     //Para el knockback del enemigo, se lo añadimos manualmente
     public float knockBackForce = 5000f;
 

     public Collider2D swordCollider;

     void Start(){
          if(swordCollider == null){
               Debug.LogWarning("El Collider de la espada no está establecido.");
          }
     }


     void OnCollisionEnter2D(Collision2D colision){
    
          colision.collider.SendMessage("OnHit", swordDamage);
  
     }
     
     // //Busca una física del enemigo (su Rigidbody) y manda on hit daño al gameObject
     // void OnCollisionEnter2D(Collider2D colision){

     //      //convertimos objeto asociado a collider en una interfaz específica (para que obtenga fuerza)
     //      IDamageable damageableObject = colision.GetComponent<IDamageable>();

     //      if(damageableObject != null){

     //           //lo hacemos vector3, para poder calcular después. Sacamos la posicion del padre
     //           Vector3 parentPosition = gameObject.GetComponentInParent<Transform>().position;
     //           //calculamos el vector que apunta desde el objeto colisionado hacia la posición del objeto padre, luego normaliza para obtener solo la dirección
     //           Vector2 direction = (Vector2)(parentPosition - colision.gameObject.transform.position).normalized;
     //           //Añadimos fuerza
     //           Vector2  knockback = direction * knockBackForce;

     //           //colision.collider.SendMessage("OnHit", swordDamage, knockback);
     //           //Implementamos método
     //           damageableObject.OnHit(swordDamage, knockback);
     //      }
     //      else{
     //           Debug.LogWarning("El collider no contiene la interfaz IDamageable!!");
     //      }


     // }
}