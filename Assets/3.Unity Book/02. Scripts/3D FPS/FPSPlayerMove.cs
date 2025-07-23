using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class FPSPlayerMove : MonoBehaviour
{
    private CharacterController cc;
    private Animator anim;

    public float moveSpeed = 7f;

    private float gravity = -20f;
    private float yVelocity = 0f;

    public float jumpPower = 10f;
    public bool isJumping = false;

    public int hp = 20;

    private int maxHp = 20;
    public Slider hpSlider;

    public GameObject hitEffect;

    void Start()
    {
        cc = GetComponent<CharacterController>();
        anim = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        if (FPSGameManager.Instance.gState != FPSGameManager.GameState.Run)
            return;

        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 dir = new Vector3(h, 0, v); // ũ��� ������ �ִ� ����
        dir = dir.normalized; // ���⸸ �ִ� ����

        anim.SetFloat("MoveMotion", dir.magnitude);

        // ī�޶��� Transform �������� ��ȯ
        dir = Camera.main.transform.TransformDirection(dir);

        // �߷� ����
        yVelocity += gravity * Time.deltaTime;
        dir.y = yVelocity;

        cc.Move(dir * moveSpeed * Time.deltaTime); // ĳ���� ��Ʈ�ѷ��� ����� �̵� ���

        if (cc.collisionFlags == CollisionFlags.Below) // �Ʒ��ʿ� �����ΰ� ���� ����
        {
            if (isJumping)
                isJumping = false;

            yVelocity = 0f;
        }

        // ���� ���
        if (Input.GetButtonDown("Jump") && !isJumping) // 2�� ���� ����
        {
            isJumping = true;
            yVelocity = jumpPower; // �����ϴ� ������ yVelocity�� �ʱ�ȭ
        }
    }

    public void DamageAction(int damage)
    {
        hp -= damage;

        hpSlider.value = (float)hp / (float)maxHp;

        if (hp > 0)
        {
            StartCoroutine(PlayHitEffect());
        }
    }

    IEnumerator PlayHitEffect()
    {
        hitEffect.SetActive(true);

        yield return new WaitForSeconds(0.3f);
        hitEffect.SetActive(false);
    }
}