using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    private float currentTime; // 타이머

    private float minTime = 1;
    private float maxTime = 5;

    public float createTime = 1f; // 생성 주기

    public GameObject enemyFactory;

    void Start()
    {
        createTime = Random.Range(minTime, maxTime);
    }
    void Update()
    {
        currentTime += Time.deltaTime;

        if (currentTime > createTime) // 타이머가 생성 주기를 넘었다면
        {
            // 생성
            GameObject enemy = Instantiate(enemyFactory);
            enemy.transform.position = transform.position;

            // 타이머 초기화
            currentTime = 0f;
        }
    }
}