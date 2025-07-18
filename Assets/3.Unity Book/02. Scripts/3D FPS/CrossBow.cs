using System.Collections;
using UnityEngine;

public class CrossBow : MonoBehaviour
{
    public GameObject arrowPrefab;
    public Transform shootPos;

    bool isShoot;

    private void Update()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        bool isTargeting = Physics.Raycast(ray, out hit);
        if (isTargeting)
        {
            GameObject arrow = Instantiate(arrowPrefab, transform);
            arrow.transform.SetPositionAndRotation(shootPos.position, Quaternion.identity);
        }
    }

    IEnumerator ShootRoutine()
    {
        isShoot = true;

        GameObject arrow = Instantiate(arrowPrefab, transform);
        Quaternion rot = Quaternion.Euler(new Vector3(90, 0, 0));
        arrow.transform.SetPositionAndRotation(shootPos.position, rot);
        yield return new WaitForSeconds(3f);

    }

}
