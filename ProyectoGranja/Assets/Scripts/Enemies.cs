using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies : MonoBehaviour
{
    public bool si = false;

    void OnHit(float danio){
        si = true;
        Debug.Log("Le ha dado " + danio + " de daño.");
    }
}
