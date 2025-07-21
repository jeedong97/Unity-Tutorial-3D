using System;
using System.Collections;
using UnityEngine;

public class CrossBow : MonoBehaviour
{
    public GameObject arrowPrefab;
    public Transform shootPos;
    public bool isShoot;

    void Update()
    {
        Ray ray = new Ray(shootPos.position, shootPos.forward);
        RaycastHit hit; // ������ ���� ���

        bool isTargeting = Physics.Raycast(ray, out hit, 100f);

        Debug.DrawRay(shootPos.position, shootPos.forward * 100f, Color.green);

        if (isTargeting && !isShoot)
        {
            print(hit.point);
            StartCoroutine(ShootRoutine());
        }
    }

    IEnumerator ShootRoutine()
    {
        isShoot = true;
        Ray ray = new Ray(shootPos.position, shootPos.forward);
        RaycastHit hit;
        Physics.Raycast(ray, out hit, 100f);

        if (Physics.Raycast(ray, out hit, 100f))
        {
            // 1. �浹 ���� ��ġ
            Vector3 hitPoint = hit.point;

            // 2. ȭ���� ������ ���� (��� ���� �ݴ� ����)
            Quaternion rot = Quaternion.Euler(new Vector3(90, 0, 0));

            // 3. ȭ�� ���� (�θ� �浹�� ��ü�� ����)
            GameObject arrow = Instantiate(arrowPrefab, hitPoint, rot, hit.transform);

            // 4. (����) �ణ ������ �İ��� ������
            arrow.transform.position += -hit.normal * 0.1f;
        }

        //GameObject arrow = Instantiate(arrowPrefab, h);
        //Quaternion rot = Quaternion.Euler(new Vector3(90, 0, 0));
        //arrow.transform.SetPositionAndRotation(Vector3.one, rot);

        yield return new WaitForSeconds(3f);
        isShoot = false;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawRay(shootPos.position, shootPos.forward * 100f);
    }
}