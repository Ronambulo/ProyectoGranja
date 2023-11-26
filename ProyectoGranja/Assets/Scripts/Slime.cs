using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : MonoBehaviour
{
    
    void OnHit(float danio){
        Debug.Log("Le ha dado " + danio + " de daño.");
    }
}
