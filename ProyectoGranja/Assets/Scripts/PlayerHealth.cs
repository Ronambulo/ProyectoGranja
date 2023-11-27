using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour, IDamageable
{
    public float VidaEnemigo { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

    public float vida = 10f;
    public bool targeteable;

    public void ObjectDestroy()
    {
        throw new System.NotImplementedException();
    }

    public void OnHit(float danio, Vector2 knockback)
    {
        throw new System.NotImplementedException();
    }

    public void OnHit(float danio)
    {
        throw new System.NotImplementedException();
    }

    public void Start()
    {
        Debug.Log("hola");
    }

}
