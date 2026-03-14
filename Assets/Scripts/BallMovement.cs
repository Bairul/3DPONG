using UnityEngine;

public class BallMovement : MonoBehaviour
{
    private float moveSpeed = 15f;
    private Rigidbody rb;
    

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        rb.useGravity = false;
    }

    void Update()
    {
        rb.linearVelocity = transform.forward * moveSpeed;
    }

    void OnCollisionEnter(Collision collision)
    {
        moveSpeed = -moveSpeed;
    }
}
