using UnityEngine;

public class BallMovement : MonoBehaviour, IBallBehavior
{
    private float moveSpeed = 20f;
    private Rigidbody rb;
    

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        rb.useGravity = false;
        rb.linearVelocity = transform.forward * moveSpeed;
    }

    public void OnHitByPaddle(Vector3 direction)
    {
        rb.linearVelocity = direction * moveSpeed;
    }
}
