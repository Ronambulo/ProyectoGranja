using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DineroScript : MonoBehaviour
{
    public int dinero = 0;
    public int dineroCaracter
    {
        //Encapsulamos variables en una clase y proporcionamos un control m�s preciso (es un setter)
        set
        {
            dinero = value;
        }
        
        //GETTER
        get
        {
            return dinero;
        }
    }

    public void addMoney(int add){
        dinero = dinero + add;
    }
}
