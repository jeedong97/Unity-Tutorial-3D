using UnityEngine;

public class BombAction : MonoBehaviour
{
    public GameObject bombEffect;
    public int attackPower = 10;
    public float explostionRadius = 5f;


    private void OnCollisionEnter(Collision collision) // 수류탄이 무엇인가 충돌할 경우
    {
        Collider[] cols = Physics.OverlapSphere(transform.position, explostionRadius, 1 << 9);


        Debug.Log($"담긴 수 : {cols.Length}");

        for (int i = 0; i < cols.Length; i++)
        {
            cols[i].GetComponent<EnemyFSM>().HitEnemy(attackPower);
        }

        GameObject eff = Instantiate(bombEffect); // 파티클 생성
        eff.transform.position = transform.position; // 파티클 위치 초기화

        Destroy(gameObject);
    }
}