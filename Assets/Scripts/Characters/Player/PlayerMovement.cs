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
    [SerializeField] private InputReader _inputReader;

    private float _rayDistance = 0.6f;
    private Rigidbody2D _rigidbody;
    private float _direction;
    private bool _isJumping;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _inputReader.InputReceived += ReadInput;
    }

    private void FixedUpdate()
    {
        Move(_direction);
        Jump(_isJumping);
    }

    private void ReadInput(float direction, bool isJumping)
    {
        _direction = direction;
        _isJumping = isJumping;
    }

    private void Move(float direction)
    {
        float distance = direction * _moveSpeed;

        _rigidbody.velocity = new(distance * PhysicsFactor * Time.deltaTime, _rigidbody.velocity.y);
    }

    private void Jump(bool isJumping)
    {
        if (isJumping == false)
            return;

        if (OnGround())
            _rigidbody.AddForce(_jumpHeight * Vector2.up, ForceMode2D.Impulse);
    }

    private bool OnGround() =>
        Physics2D.Raycast(_rigidbody.position, Vector2.down, _rayDistance, _ground);
}
