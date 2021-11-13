using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumberPicker : MonoBehaviour
{
    public int PickRandomNumber()
    {
        int nmbr = Random.Range(0, 999999999);
        // No he querido usar "int.MaxValue" para evitar numeros excesivamente largos y complejos
        return nmbr;
    }
}
