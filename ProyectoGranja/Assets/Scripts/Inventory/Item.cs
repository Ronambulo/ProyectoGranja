using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Item : MonoBehaviour
{
    public ItemData data;

    [HideInInspector]public Rigidbody2D rgbd;

    private void Awake()
    {
        rgbd = GetComponent<Rigidbody2D>();
    }

}
