using UnityEngine;

public class Enemy : MonoBehaviour
{
    private const float PhysicsFactor = 100;

    [SerializeField] private CharacterAnimator _animator;
    [SerializeField] private Transform _patrolPointsParent;
    [SerializeField] private float _speed;

    private SpriteRenderer _spriteRenderer;
    private Rigidbody2D _rigidbody;
    private float[] _patrolXCoordinates;
    private float _patroolDeviation = 1f;
    private int _index;

    private void Awake()
    {
        _patrolXCoordinates = new float[_patrolPointsParent.childCount];

        for (int i = 0; i < _patrolPointsParent.childCount; i++)
            _patrolXCoordinates[i] = _patrolPointsParent.GetChild(i).transform.position.x;

        _rigidbody = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        Move();

        _animator.SetSpeed(_rigidbody.velocity);
    }

    private void Move()
    {
        if (IsPatrolPointNear())        
            _index = (_index + 1) % _patrolXCoordinates.Length;       

        float direction = _patrolXCoordinates[_index] - transform.position.x;
        float distance = direction * _speed * Time.deltaTime;

        _spriteRenderer.flipX = direction < 0;
        _rigidbody.velocity = new(distance * PhysicsFactor, _rigidbody.velocity.y);
    }

    private bool IsPatrolPointNear()
    {
        if (_patrolXCoordinates[_index] - _patroolDeviation < transform.position.x && transform.position.x < _patrolXCoordinates[_index] + _patroolDeviation)        
            return true;        

        return false;
    }
}
