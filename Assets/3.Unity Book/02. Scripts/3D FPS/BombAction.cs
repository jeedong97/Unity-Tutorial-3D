using UnityEngine;

public class BombAction : MonoBehaviour
{
    public GameObject bombEffect;
    public int attackPower = 10;
    public float explostionRadius = 5f;


    private void OnCollisionEnter(Collision collision) // ����ź�� �����ΰ� �浹�� ���
    {
        Collider[] cols = Physics.OverlapSphere(transform.position, explostionRadius, 1 << 9);


        Debug.Log($"��� �� : {cols.Length}");

        for (int i = 0; i < cols.Length; i++)
        {
            cols[i].GetComponent<EnemyFSM>().HitEnemy(attackPower);
        }

        GameObject eff = Instantiate(bombEffect); // ��ƼŬ ����
        eff.transform.position = transform.position; // ��ƼŬ ��ġ �ʱ�ȭ

        Destroy(gameObject);
    }
}