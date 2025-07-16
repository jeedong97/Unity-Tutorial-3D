using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    private float currentTime; // Ÿ�̸�

    private float minTime = 1;
    private float maxTime = 5;

    public float createTime = 1f; // ���� �ֱ�

    public GameObject enemyFactory;

    void Start()
    {
        createTime = Random.Range(minTime, maxTime);
    }
    void Update()
    {
        currentTime += Time.deltaTime;

        if (currentTime > createTime) // Ÿ�̸Ӱ� ���� �ֱ⸦ �Ѿ��ٸ�
        {
            // ����
            GameObject enemy = Instantiate(enemyFactory);
            enemy.transform.position = transform.position;

            // Ÿ�̸� �ʱ�ȭ
            currentTime = 0f;
        }
    }
}