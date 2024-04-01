using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private const string Horizontal = nameof(Horizontal);
    private const string Vertical = nameof(Vertical);
    private const float PhysicsFactor = 100;

    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _jumpHeight;
    [SerializeField] private CharacterAnimator _animator;

    private float _rayDistance = 0.6f;
    private bool _onGround;
    private KeyCode _jumpKey = KeyCode.Space;
    private Rigidbody2D _rigidbody;
    private SpriteRenderer _spriteRenderer;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _onGround = OnGround();
    }

    private void FixedUpdate()
    {
        _onGround = OnGround();

        Move();

        _animator.SetOnGround(_onGround);
        _animator.SetSpeed(_rigidbody.velocity);
    }

    private void Update() =>
        Jump();

    private void Move()
    {
        float direction = Input.GetAxis(Horizontal);
        float distance = direction * _moveSpeed * Time.deltaTime;

        _spriteRenderer.flipX = direction < 0;
        _rigidbody.velocity = new(distance * PhysicsFactor, _rigidbody.velocity.y);
    }

    private void Jump()
    {
        if (Input.GetKeyDown(_jumpKey))        
            if (_onGround)
                _rigidbody.AddForce(_jumpHeight * Vector2.up, ForceMode2D.Impulse);        
    }

    private bool OnGround() =>
        Physics2D.Raycast(_rigidbody.position, Vector2.down, _rayDistance, LayerMask.GetMask("Ground")).collider;
}
