using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class BallMovement : MonoBehaviour, IBallBehavior
{
    private float moveSpeed = 20f;
    private Rigidbody rb;
    private Vector3 startPosition;

    private float resetDelay = 1.5f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        rb.useGravity = false;

        startPosition = transform.position;
        rb.linearVelocity = transform.forward * moveSpeed;
        
    }

    public void OnHitByPaddle(Vector3 direction)
    {
        rb.linearVelocity = direction * moveSpeed;
    }

    public void ResetBall(bool isPlayerWin)
    {
        StartCoroutine(DelayedLaunch(isPlayerWin));
    }

    private IEnumerator DelayedLaunch(bool isPlayerWin)
    {
        transform.position = startPosition;
        rb.linearVelocity = Vector3.zero;
        yield return new WaitForSeconds(resetDelay);
        rb.linearVelocity = (isPlayerWin ? Vector3.forward : Vector3.back) * moveSpeed;
    }
}
