using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class MoveScirpt : MonoBehaviour
{
    public float moveSpeed = 1f;
    public float runSpeed = 8f;      // Tốc độ chạy
    public float rotateSpeed = 10f;

    public int point = 0;

    private Animator animator;
    public Transform cameraTransform;

    private Rigidbody rb;

    public void AddPoint(int point)
    {
        this.point += point;
    }

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;

        animator = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        Vector3 camForward = cameraTransform.forward;
        Vector3 camRight = cameraTransform.right;

        camForward.y = 0;
        camRight.y = 0;

        camForward.Normalize();
        camRight.Normalize();

        Vector3 moveDirection = camForward * v + camRight * h;

        if (moveDirection.sqrMagnitude > 1f)
            moveDirection.Normalize();

        // Giữ Shift để chạy
        bool isRunning = Input.GetKey(KeyCode.LeftShift);

        float currentSpeed = isRunning ? runSpeed : moveSpeed;

        if (moveDirection.sqrMagnitude > 0.01f)
        {
            rb.MovePosition(rb.position + moveDirection * currentSpeed * Time.fixedDeltaTime);

            Quaternion targetRotation = Quaternion.LookRotation(moveDirection);

            rb.MoveRotation(
                Quaternion.Slerp(
                    rb.rotation,
                    targetRotation,
                    rotateSpeed * Time.fixedDeltaTime));

            // Animator
            if (isRunning)
                animator.SetInteger("State", 2);   // Run
            else
                animator.SetInteger("State", 1);   // Walk
        }
        else
        {
            animator.SetInteger("State", 0);       // Idle
        }
    }
}