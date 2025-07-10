using UnityEngine;

public class Fibonacci : MonoBehaviour
{
    private void Start()
    {
        for (int i = 0; i < 10; i++)
        {
            int result = FibonacciFunction(i);
            Debug.Log(result);
        }
    }
    int FibonacciFunction(int n)
    {
        if (n <= 1)
            return 1;
        return FibonacciFunction(n - 1) + FibonacciFunction(n - 2);
    }
}
