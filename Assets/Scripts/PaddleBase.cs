using UnityEngine;

public abstract class PaddleBase : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            IBallBehavior ball = collision.gameObject.GetComponent<IBallBehavior>();
            Vector3 direction = CalculateBounceDirection(collision);
            ball.OnHitByPaddle(direction);
        }
    }

    Vector3 CalculateBounceDirection(Collision collision)
    {
        Vector3 offset = collision.contacts[0].point - transform.position;
        return new Vector3(
            offset.x,
            offset.y,
            -transform.position.z
        ).normalized;
    }
}