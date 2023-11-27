//INTERFAZ PARA CUALQUIER OBJETO QUE CONTENGA DAÑO
using UnityEngine;

public interface IDamageable{

    public float VidaEnemigo { set; get; }
    public void OnHit(float danio, Vector2 knockback);
    public void OnHit(float danio);
    public void ObjectDestroy(); 
}