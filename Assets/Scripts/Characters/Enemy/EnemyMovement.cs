using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private Transform _patrolPointsParent;
    [SerializeField] private float _speed;
    [SerializeField] private LayerMask _playerMask;

    private Rigidbody2D _rigidbody;
    private Action _move;
    private Transform[] _patrolPointsTransform;
    private float _searchDistance = 50f;
    private int _index;

    private void Awake()
    {
        _patrolPointsTransform = new Transform[_patrolPointsParent.childCount];

        for (int i = 0; i < _patrolPointsParent.childCount; i++)
            _patrolPointsTransform[i] = _patrolPointsParent.GetChild(i).transform;

        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        _move = SearchPlayer() ? FollowPlayer : FollowPatrolPoints;

        _move.Invoke();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform == _patrolPointsTransform[_index])
            _index = (_index + 1) % _patrolPointsTransform.Length;
    }

    private bool SearchPlayer() =>
        Physics2D.Raycast(transform.position, transform.right, _searchDistance, _playerMask);

    private void FollowPlayer() =>
        _rigidbody.velocity = new(transform.right.x * _speed, _rigidbody.velocity.y);

    private void FollowPatrolPoints()
    {
        float direction = _patrolPointsTransform[_index].position.x - transform.position.x;
        direction /= Mathf.Abs(direction);

        float velocityX = direction * _speed;

        _rigidbody.velocity = new(velocityX, _rigidbody.velocity.y);
    }
}
