using UnityEngine;

public class SelectionSort : MonoBehaviour
{
    int[] array = { 5, 2, 1, 8, 3, 7, 6, 4 };
    private void Start()
    {
        Debug.Log("정렬 전" + string.Join(", ", array));

        Selection(array);
        Debug.Log("정렬 후 :" + string.Join(", ", array));
    }
    private void Selection(int[] arr)
    {
        int n = array.Length;
        for (int i = 0; i < n - 1; i++)
        {
            int minIdx = i;
            for (int j = i + 1; j < n; j++)
            {
                if (arr[j] < arr[minIdx])
                {
                    minIdx = j;
                }
            }
            int temp = arr[i];
            arr[i] = arr[minIdx];
            arr[minIdx] = temp;
        }
    }
}
