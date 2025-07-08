using System.Collections.Generic;
using UnityEngine;

public class StudyLinkedList : MonoBehaviour
{
    public LinkedList<int> linkedList1 = new LinkedList<int>();
    public LinkedListNode<int> node2;
    private void Start()
    {
        for(int i = 0; i < 10; i++)
        {
            linkedList1.AddLast(i);
        }

        linkedList1.AddFirst(100);
        linkedList1.AddLast(500);

        var node = linkedList1.AddFirst(1);

        linkedList1.AddBefore(node, 200);
        linkedList1.AddAfter(node2, 300);
    }
}
