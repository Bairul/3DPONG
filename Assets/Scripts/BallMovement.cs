using UnityEngine;

public class BallMovement : MonoBehaviour
{
    private float moveSpeed = 20f;
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
        string hitName = collision.gameObject.name;

        if (hitName == "EnemyEndWall")
        {
            Debug.Log("Enemy Wall Hitt");
        }
        else if (hitName == "PlayerEndWall")
        {
            Debug.Log("Player Wall Hitt");
        }
    }
}
