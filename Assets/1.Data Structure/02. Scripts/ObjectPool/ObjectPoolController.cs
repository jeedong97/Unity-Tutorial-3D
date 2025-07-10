using UnityEngine;

public class ObjectPoolController : MonoBehaviour
{
    public ObjectPoolQueue pool;
    public Transform shootPos;
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            GameObject bullet = pool.DeQueueObject();
            bullet.transform.position = shootPos.position;
        }
    }
}
