using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class BallMovement : MonoBehaviour
{
    private float moveSpeed = 20f;
    private Rigidbody rb;
    private Vector3 startPosition;

    private bool isInPlay;
    private float resetDelay = 1.5f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        rb.useGravity = false;

        startPosition = transform.position;
        ResetBall(true);
    }

    void FixedUpdate()
    {
        if (!isInPlay) return;
        rb.linearVelocity = transform.forward * moveSpeed;
    }

    void OnCollisionEnter(Collision collision)
    {
        moveSpeed = -moveSpeed;
    }

    public void ResetBall(bool playerWin)
    {
        isInPlay = false;
        rb.linearVelocity = Vector3.zero;
        transform.SetPositionAndRotation(startPosition, Quaternion.Euler(Vector3.zero));
        StartCoroutine(DelayedLaunch(playerWin));
    }

    private IEnumerator DelayedLaunch(bool toPlayerSide)
    {
        yield return new WaitForSeconds(resetDelay);
        isInPlay = true;
        moveSpeed = Math.Abs(moveSpeed);
        moveSpeed *= toPlayerSide ? 1: -1;
    }
}
