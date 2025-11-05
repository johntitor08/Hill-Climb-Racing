using UnityEngine;

public class DriveCar : MonoBehaviour
{
    [SerializeField] private Rigidbody2D frontTireRb;
    [SerializeField] private Rigidbody2D backTireRb;
    [SerializeField] private Rigidbody2D carRb;
    [SerializeField] private float speed = 150;
    [SerializeField] private float rotationSpeed = 300;
    private float moveInput;

    private void Update()
    {
        moveInput = Input.GetAxisRaw("Horizontal");

    }

    private void FixedUpdate()
    {
        frontTireRb.AddTorque(-moveInput * speed * Time.fixedDeltaTime);
        backTireRb.AddTorque(-moveInput * speed * Time.fixedDeltaTime);
        carRb.AddTorque(moveInput * rotationSpeed * Time.fixedDeltaTime);

    }

}