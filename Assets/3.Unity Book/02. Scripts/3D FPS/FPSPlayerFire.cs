using System.Collections;
using TMPro;
using UnityEngine;

public class FPSPlayerFire : MonoBehaviour
{
    private enum WeaponMode { Normal, Sniper }
    private WeaponMode wMode;

    public GameObject firePosition;
    public GameObject bombFactory;
    public GameObject bulletEffect;
    private Animator anim;
    private ParticleSystem ps;

    public TextMeshProUGUI wModeText;
    public GameObject[] eff_Flash;

    public float throwPower = 15f;
    public int weaponPower = 5;

    private bool ZoomMode = false;

    void Start()
    {
        anim = GetComponentInChildren<Animator>();
        ps = bulletEffect.GetComponent<ParticleSystem>();

        wMode = WeaponMode.Normal;
    }

    void Update()
    {
        if (FPSGameManager.Instance.gState != FPSGameManager.GameState.Run)
            return;

        if (Input.GetMouseButtonDown(0)) // ���콺 ���� ��ư Ŭ��
        {
            if (anim.GetFloat("MoveMotion") == 0)
                anim.SetTrigger("Attack");

            StartCoroutine(ShootEffectOn(0.05f));

            Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
            RaycastHit hitInfo = new RaycastHit();

            if (Physics.Raycast(ray, out hitInfo))
            {
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
            switch (wMode)
            {
                case WeaponMode.Normal: // �Ϲ� ����� �� ���콺 ������ -> ����ź ��ô
                    GameObject bomb = Instantiate(bombFactory);
                    bomb.transform.position = firePosition.transform.position;

                    Rigidbody rb = bomb.GetComponent<Rigidbody>();
                    rb.AddForce(Camera.main.transform.forward * throwPower, ForceMode.Impulse);
                    break;
                case WeaponMode.Sniper: // ���� ����� �� ���콺 ������ -> Ȯ��/��� ���ذ�
                    // if (!ZoomMode)
                    // {
                    //     Camera.main.fieldOfView = 15f;
                    //     ZoomMode = true;
                    // }
                    // else
                    // {
                    //     Camera.main.fieldOfView = 60f;
                    //     ZoomMode = false;
                    // }

                    float fov = ZoomMode ? 60f : 15f;
                    Camera.main.fieldOfView = fov;
                    ZoomMode = !ZoomMode;
                    break;
            }
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            wMode = WeaponMode.Normal;
            Camera.main.fieldOfView = 60f;

            wModeText.text = "Normal Mode";
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            wMode = WeaponMode.Sniper;

            wModeText.text = "Sniper Mode";
        }
    }

    IEnumerator ShootEffectOn(float duration)
    {
        int num = Random.Range(0, eff_Flash.Length - 1);
        eff_Flash[num].SetActive(true);

        yield return new WaitForSeconds(duration);
        eff_Flash[num].SetActive(false);
    }
}