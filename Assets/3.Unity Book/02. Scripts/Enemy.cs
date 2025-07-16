using System;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Vector3 dir;
    public float speed = 5;

    public GameObject explosionFactory;

    void Start()
    {
        int ranValue = UnityEngine.Random.Range(0, 10);

        if (ranValue < 3) // 30%
        {
            GameObject target = GameObject.Find("Player");
            dir = target.transform.position - transform.position; // �÷��̾ �ٶ󺸴� ���� ��
            dir.Normalize();
        }
        else // 70%
        {
            dir = Vector3.down;
        }
    }

    void Update()
    {
        transform.position += dir * speed * Time.deltaTime;
    }

    private void OnCollisionEnter(Collision other)
    {
        // ���� ����
        GameObject smObject = GameObject.Find("ScoreManager");
        ScoreManager sm = smObject.GetComponent<ScoreManager>();

        // sm.SetScore(sm.GetScore() + 1); // å�� ���� ��
        var score = sm.GetScore() + 1;
        sm.SetScore(score);

        // ��ƼŬ ����
        GameObject explosion = Instantiate(explosionFactory);
        explosion.transform.position = transform.position;

        // �ı� ���
        Destroy(other.gameObject);
        Destroy(gameObject);
    }
}