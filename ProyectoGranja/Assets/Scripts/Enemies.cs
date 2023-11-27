using System.Collections;
using System.Collections.Generic;
using UnityEngine;

                                    //Añadimos nuestra interfaz creada
public class Enemies : MonoBehaviour
{
    public float damage = 1;

    public float knockbackForce = 800f;

    //Este método lo que hace es llamarse cuando el objeto colisiona con otro objeto
    void OnCollisionEnter2D(Collision2D colision) {

        // obtenemos componente que implementa la interfaz IDamageable del collider del objeto con el que ha colisionado
         IDamageable damageable = colision.collider.GetComponent<IDamageable>();

        /*Collider2D collider = colision.collider;
         IDamageable damageableObject = collider.GetComponent<IDamageable>();*/

        if (damageable != null)
        {
            //Pasamos valor del daño
             damageable.OnHit(damage);
        }
        


        //IGUAL, FÍSICAS QUE NO ME SALEN---------------------------------------
        /*if (damageableObject != null) {

            //lo hacemos vector3, para poder calcular después. Sacamos la posicion del padre
            Vector3 parentPosition = gameObject.GetComponentInParent<Transform>().position;
            //calculamos el vector que apunta desde el objeto colisionado hacia la posición del objeto padre, luego normaliza para obtener solo la dirección
            Vector2 direction = (Vector2)(collider.transform.position - transform.position).normalized;
            //Añadimos fuerza
            Vector2 knockback = direction * knockbackForce;

            //colision.collider.SendMessage("OnHit", swordDamage, knockback);
            //Implementamos método
            Debug.Log(knockback);
            damageableObject.OnHit(damage, knockback);
        }*/
    }


}
