using UnityEngine;

public class JaggedArray : MonoBehaviour
{
    public int[] array1 = new int[3];
    public int[][] jaggedArrya1 = new int[3][];

    private void Start()
    {
        array1[0] = 1;
        jaggedArrya1[0] = new int[3] { 1, 2, 3 };
        jaggedArrya1[1] = new int[2] { 4, 5 };
        jaggedArrya1[2] = new int[5] { 6, 7, 8, 9, 10 };
    }
}
