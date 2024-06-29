using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    private const string Horizontal = nameof(Horizontal);
    private const string Vertical = nameof(Vertical);
    private const float PhysicsFactor = 10;

    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _jumpHeight;
    [SerializeField] private LayerMask _ground;

    private float _rayDistance = 0.6f;
    private InputReader _inputReader = new();
    private Rigidbody2D _rigidbody;

    private void Awake() => 
        _rigidbody = GetComponent<Rigidbody2D>();

    private void FixedUpdate()
    {
        Move();
        Jump();
    }

    private void Move()
    {
        float distance = _inputReader.Direction * _moveSpeed;

        _rigidbody.velocity = new(_inputReader.Direction * _moveSpeed, _rigidbody.velocity.y);
    }

    private void Jump()
    {
        if (_inputReader.IsJump && IsOnGround())
            _rigidbody.AddForce(_jumpHeight * Vector2.up, ForceMode2D.Impulse);
    }

    private bool IsOnGround() =>
        Physics2D.Raycast(_rigidbody.position, Vector2.down, _rayDistance, _ground);
}
