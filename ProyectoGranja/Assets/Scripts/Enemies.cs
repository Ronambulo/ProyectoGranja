using System.Collections;
using System.Collections.Generic;
using UnityEngine;

                                    //Añadimos nuestra interfaz creada
public class Enemies : MonoBehaviour
{
    public float damage = 1;
    
    //Este método lo que hace es llamarse cuando el objeto colisiona con otro objeto
    void OnCollisionEnter2D(Collision2D colision){
        
        // obtenemos componente que implementa la interfaz IDamageable del collider del objeto con el que ha colisionado
        IDamageable damageable = colision.collider.GetComponent<IDamageable>();

        if (damageable != null) {
            //Pasamos valor del daño
            damageable.OnHit(damage);
        }
    }
}
