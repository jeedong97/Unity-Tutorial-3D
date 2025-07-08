using System.Collections.Generic;
using UnityEngine;

public class DanamicArray : MonoBehaviour
{
    private object[] array = new object[3];

    List<int> newLists1 = new List<int>();
    List<int> newLists2 = new List<int>() { 1,2,3,4,5};
    List<int> newLists3 = new List<int>();
    void Add(object o)
    {
        var temp = new object[array.Length + 1];
        for (int i = 0; i < array.Length; i++)
        {
            temp[i] = array[i];
        }
        array = temp;
        array[array.Length-1] = o;
    }

    private void Start()
    {
        newLists1.Add(0);
        newLists2.Add(0);
        newLists3.Add(0);
    }
}
