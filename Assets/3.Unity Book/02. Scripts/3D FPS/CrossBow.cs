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
        RaycastHit hit; // 레이저 닿은 대상

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
            // 1. 충돌 지점 위치
            Vector3 hitPoint = hit.point;

            // 2. 화살이 박히는 방향 (노멀 기준 반대 방향)
            Quaternion rot = Quaternion.Euler(new Vector3(90, 0, 0));

            // 3. 화살 생성 (부모를 충돌한 객체로 설정)
            GameObject arrow = Instantiate(arrowPrefab, hitPoint, rot, hit.transform);

            // 4. (선택) 약간 안으로 파고들게 오프셋
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