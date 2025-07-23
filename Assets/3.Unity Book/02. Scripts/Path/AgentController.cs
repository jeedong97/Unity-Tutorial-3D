using UnityEngine;
using UnityEngine.AI;

public class AgentController : MonoBehaviour
{
    private Transform player;
    private NavMeshAgent agent;

    public Transform[] points;
    public int index;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        index = Random.Range(0, points.Length);
    }

    void Update()
    {
        agent.SetDestination(points[index].position);

        if (agent.remainingDistance <= 1.5f) // ���������� �Ÿ��� 1.5 ������ ���
        {
            Debug.Log("������ ����");

            int temp = index;
            index = Random.Range(0, points.Length);

            if (temp == index)
                index = Random.Range(0, points.Length);
        }
    }
}