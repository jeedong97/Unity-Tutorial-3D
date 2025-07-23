using UnityEngine;
using UnityEngine.PlayerLoop;

public class FPSPlayerFire : MonoBehaviour
{
    public GameObject firePosition;
    public GameObject bombFactory;
    public GameObject bulletEffect;
    Animator anim;

    public float throwPower = 15f;
    public int weaponPower = 5;

    private ParticleSystem ps;

    void Start()
    {
        anim = GetComponentInChildren<Animator>();
        ps = bulletEffect.GetComponent<ParticleSystem>();
    }

    void Update()
    {
        if (FPSGameManager.Instance.gState != FPSGameManager.GameState.Run)
            return;

        if (Input.GetMouseButtonDown(0)) // ���콺 ���� ��ư Ŭ��
        {
            Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
            RaycastHit hitInfo = new RaycastHit();

            if (Physics.Raycast(ray, out hitInfo))
            {
                if(anim.GetFloat("MoveMotion") == 0)
                {
                    anim.SetTrigger("Attack");
                }

                if (hitInfo.transform.gameObject.layer == LayerMask.NameToLayer("Enemy")) // Raycast�� Enemy�� ���� ���
                {
                    EnemyFSM eFSM = hitInfo.transform.GetComponent<EnemyFSM>();
                    eFSM.HitEnemy(weaponPower);
                }
                else // Raycast�� ���� ����� Enemy�� �ƴ� ���
                {
                    bulletEffect.transform.position = hitInfo.point;
                    bulletEffect.transform.forward = hitInfo.normal;

                    ps.Play();
                }
            }
        }

        if (Input.GetMouseButtonDown(1)) // ���콺 ������ ��ư Ŭ��
        {
            GameObject bomb = Instantiate(bombFactory);
            bomb.transform.position = firePosition.transform.position;

            Rigidbody rb = bomb.GetComponent<Rigidbody>();
            rb.AddForce(Camera.main.transform.forward * throwPower, ForceMode.Impulse);
        }
    }
}