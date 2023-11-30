using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dialogue
{
    public string nombreNPC;
    
    [TextArea(1, 4)]
    public string[] frases;
}
