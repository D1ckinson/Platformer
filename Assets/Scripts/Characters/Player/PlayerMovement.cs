using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    private const string Horizontal = nameof(Horizontal);
    private const string Vertical = nameof(Vertical);
    private const float PhysicsFactor = 10;

    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _jumpHeight;
    [SerializeField] private LayerMask _groundMask;

    private float _rayDistance = 0.6f;
    private KeyCode _jumpKey = KeyCode.Space;
    private Rigidbody2D _rigidbody;

    private void Awake() =>
        _rigidbody = GetComponent<Rigidbody2D>();

    private void Update()
    {
        Move();
        Jump();
    }

    private void Move()
    {
        float direction = Input.GetAxis(Horizontal);
        float distance = direction * _moveSpeed;

        _rigidbody.velocity = new(distance * PhysicsFactor * Time.deltaTime, _rigidbody.velocity.y);
    }

    private void Jump()
    {
        if (Input.GetKeyDown(_jumpKey))
            if (OnGround())
                _rigidbody.AddForce(_jumpHeight * Vector2.up, ForceMode2D.Impulse);
    }

    private bool OnGround() =>
        Physics2D.Raycast(_rigidbody.position, Vector2.down, _rayDistance, _groundMask);
}
