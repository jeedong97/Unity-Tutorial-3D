using System.Collections.Generic;
using UnityEngine;

public class PlayerFire : Singleton<PlayerFire>
{
    public GameObject bulletFactory;
    public GameObject firePosition;

    public int poolSize = 10;

    // public GameObject[] bulletObjectPool; // �迭
    // public List<GameObject> bulletObjectPool; // ����Ʈ
    public Queue<GameObject> bulletObjectPool; // ť

    void Start()
    {
        // bulletObjectPool = new GameObject[poolSize]; // �迭
        // bulletObjectPool = new List<GameObject>(); // ����Ʈ
        bulletObjectPool = new Queue<GameObject>(); // ť

        for (int i = 0; i < poolSize; i++)
        {
            GameObject bullet = Instantiate(bulletFactory);

            // bulletObjectPool[i] = bullet; // �迭
            // bulletObjectPool.Add(bullet); // ����Ʈ
            bulletObjectPool.Enqueue(bullet); // ť

            bullet.SetActive(false);
        }
    }

    void Update()
    {
#if UNITY_STANDARDALONE || UNITY_EDITOR
        if (Input.GetButtonDown("Fire1"))
        {
            Debug.Log("���콺 Ŭ��");
            // ť
            if (bulletObjectPool.Count > 0)
            {
                GameObject bullet = bulletObjectPool.Dequeue();
                bullet.SetActive(true);
                bullet.transform.position = firePosition.transform.position;
            }

            // ����Ʈ
            // if (bulletObjectPool.Count > 0)
            // {
            //     GameObject bullet = bulletObjectPool[0]; // ������ ������Ʈ ����
            //     bullet.SetActive(true); // ������Ʈ ���
            //     
            //     bulletObjectPool.Remove(bullet); // Pool���� ������Ʈ ����
            //     
            //     bullet.transform.position = firePosition.transform.position;
            // }

            // �迭
            // for (int i = 0; i < poolSize; i++)
            // {
            //     GameObject bullet = bulletObjectPool[i];
            //     
            //     if (!bullet.activeSelf) // ������ �Ѿ� ������Ʈ�� ��Ȱ��ȭ �������� Ȯ��
            //     {
            //         bullet.SetActive(true); // �Ѿ��� ����ϱ� ���� Ȱ��ȭ
            //         bullet.transform.position = firePosition.transform.position; // �߻� ��ġ ����
            //
            //         break; // �ݺ��� ����
            //     }
            // }
        }

#elif UNITY_ANDROID || UNITY_IOS
        if (Input.GetTouch(0).phase == TouchPhase.Began)
        {
            Debug.Log("�հ��� ��ġ");

            if (bulletObjectPool.Count > 0)
            {
                GameObject bullet = bulletObjectPool.Dequeue();
                bullet.SetActive(true);
                bullet.transform.position = firePosition.transform.position;
            }
        }
#endif
    }
}