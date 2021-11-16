using UnityEngine;

public class NumberPicker : MonoBehaviour
{
    /// <summary>
    /// Returns a random integer between 0 and 999
    /// </summary>
    /// <returns></returns>
    public int PickRandomNumber()
    {
        int number = Random.Range(0, 1000);
        // No he querido usar "int.MaxValue" para evitar numeros excesivamente largos y complejos
        return number;
    }
}
