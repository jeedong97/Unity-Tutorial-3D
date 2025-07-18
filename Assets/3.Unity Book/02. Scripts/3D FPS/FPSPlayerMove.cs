using UnityEngine;

public class FPSPlayerMove : MonoBehaviour
{
    private CharacterController cc;
    public float moveSpeed = 7f;

    float gravity = -20f;
    float yVelocity = 0;

    public float jumpPower = 10f;
    public bool isJumping = false;

    private void Start()
    {
        cc = GetComponent<CharacterController>();
    }
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 dir = new Vector3(h, 0, v); // ũ��� ������ �ִ� ����
        dir = dir.normalized; // ���⸸ �ִ� ����

        //ī�޶��� Transform �������� ��ȯ
        dir = Camera.main.transform.TransformDirection(dir);

        yVelocity += gravity * Time.deltaTime;
        dir.y = yVelocity;

        cc.Move(dir * moveSpeed * Time.deltaTime);

        if (cc.collisionFlags == CollisionFlags.Below)
        {
            if (isJumping)
            {
                isJumping = false;
            }
                yVelocity = 0;
        }

        if (Input.GetButtonDown("Jump") && !isJumping)
        {
            isJumping=true;
            yVelocity = jumpPower;
        }
    }
}