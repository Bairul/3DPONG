using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : PaddleBase
{
    private PlayerControls playerControls;
    private InputAction move;
    private Vector3 moveDirection;
    private new Rigidbody rigidbody;

    public float moveSpeed = 5f;

    [Header("Smooth Movement")]
    [SerializeField] private float acceleration = 10f;
    [SerializeField] private float deceleration = 15f;

    [Header("Wall Detection")]
    [SerializeField] private float wallCheckDistance = 1f;
    [SerializeField] private LayerMask wallLayer;

    void Awake()
    {
        playerControls = new PlayerControls();
        rigidbody = GetComponent<Rigidbody>();
        rigidbody.useGravity = false;
        rigidbody.constraints = RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotation;
    }

    void OnEnable()
    {
        move = playerControls.Player.Move;
        move.Enable();
    }

    void OnDisable()
    {
        move.Disable();
    }

    void Update()
    {
        moveDirection = move.ReadValue<Vector3>();
    }

    public void FixedUpdate()
    {
        Vector3 rawDirection = moveDirection.normalized;

        Vector3 horizontalDir = new(rawDirection.x, 0, 0);
        Vector3 verticalDir = new(0, rawDirection.y, 0);

        if (horizontalDir != Vector3.zero)
        {
            if (Physics.Raycast(transform.position, horizontalDir, wallCheckDistance, wallLayer))
                horizontalDir = Vector3.zero;
        }

        if (verticalDir != Vector3.zero)
        {
            if (Physics.Raycast(transform.position, verticalDir, wallCheckDistance, wallLayer))
                verticalDir = Vector3.zero;
        }

        Vector3 finalDirection = (horizontalDir + verticalDir).normalized;
        Vector3 targetVelocity = finalDirection * moveSpeed;

        float smoothRate = moveDirection != Vector3.zero ? acceleration : deceleration;
        rigidbody.linearVelocity = Vector3.Lerp(rigidbody.linearVelocity, targetVelocity, smoothRate * Time.fixedDeltaTime);
    }
}