using UnityEngine;

public class ScoreCounter : MonoBehaviour
{
    public int AddScore(int current, int addedValue)
    {
        current += addedValue;
        return current;
    }

    public int SubstractScore(int current, int substractedValue)
    {
        current -= substractedValue;
        return current;
    }
}
