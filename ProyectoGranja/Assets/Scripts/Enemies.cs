using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Añadimos nuestra interfaz creada
public class Enemies : MonoBehaviour
{
    public float damage = 1;

    public float knockbackForce = 800f;

    //la velocidad de los Slimes es 1.3
    public float moveSpeed = 1.3f;

    public ZonaDeteccion zonaDeteccion;

    public Rigidbody2D rb;

    Animator animator;

    void Strart(){
        rb = GetComponent<Rigidbody2D>();
    }

    

    void FixedUpdate() {
        //Hace referencia al primero de la lista de zonaDeteccion (dentro del Script ZonaDeteccion)
        //Collider2D zonaDeteccion0 = zonaDeteccion.objetosDetectados[0]; -> no funcionó

        if (zonaDeteccion.objetosDetectado.Count > 0) {

            Vector2 direction = (zonaDeteccion.objetosDetectado[0].transform.position - transform.position).normalized;

            //Ir hacia el objeto
            //rb.AddForce(sirection * moveSpeed);
            transform.Translate(direction * moveSpeed * Time.deltaTime);
        }
    }


    //Este método lo que hace es llamarse cuando el objeto colisiona con otro objeto
    void OnCollisionEnter2D(Collision2D colision) {

        // obtenemos componente que implementa la interfaz IDamageable del collider del objeto con el que ha colisionado

        Collider2D collider = colision.collider;
        IDamageable damageableObject = collider.GetComponent<IDamageable>();


        if (damageableObject != null) {

            //lo hacemos vector3, para poder calcular después. Sacamos la posicion del padre
            Vector3 parentPosition = gameObject.GetComponentInParent<Transform>().position;
            //calculamos el vector que apunta desde el objeto colisionado hacia la posición del objeto padre, luego normaliza para obtener solo la dirección
            Vector2 direction = (Vector2)(collider.transform.position - transform.position).normalized;
            //Añadimos fuerza
            Vector2 knockback = direction * knockbackForce;

            //colision.collider.SendMessage("OnHit", swordDamage, knockback);
            //Implementamos método
            //solo hace daño si no esta colisionando con un enemigo :)
            if(!colision.gameObject.CompareTag("Enemy")){
                damageableObject.OnHit(damage, knockback);
            }

        }
    }


}
