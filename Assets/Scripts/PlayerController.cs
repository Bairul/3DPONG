using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    private PlayerControls playerControls;
    private InputAction move;
    private Vector3 moveDirection;
    private new Rigidbody rigidbody;
    public float moveSpeed = 5f;

    void Awake()
    {
        playerControls = new PlayerControls();
        rigidbody = GetComponent<Rigidbody>();
        rigidbody.freezeRotation = true;
        rigidbody.useGravity = false;
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
        rigidbody.linearVelocity = moveDirection.normalized * moveSpeed;
    }
}
