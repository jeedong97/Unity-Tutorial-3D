using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ObjectPoolQueue : MonoBehaviour
{
    public Queue<GameObject> objQueue = new Queue<GameObject>();

    public GameObject objPrefab;
    public Transform parent;

    private void Start()
    {
        CreateObject();
    }
    void CreateObject()
    {
        for (int i = 0; i < 100; i++)
        {
            GameObject obj = Instantiate(objPrefab, parent);
            EnqueueObject(obj);
        }
    }
    public void EnqueueObject(GameObject obj)
    {
        obj.GetComponent<Rigidbody>().linearVelocity = Vector3.zero;
        obj.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;

        objQueue.Enqueue(obj);
        obj.SetActive(false);
    }
    public GameObject DeQueueObject()
    {
        if (objQueue.Count < 10)
        {
            CreateObject();
        }
        
        GameObject obj = objQueue.Dequeue();
        obj.SetActive(true);
        return obj;
    }
}
