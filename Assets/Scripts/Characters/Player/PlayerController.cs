using UnityEngine;
{
        _rigidbody = GetComponent<Rigidbody2D>();
        Jump();
    }
        float direction = Input.GetAxis(Horizontal);
        float distance = direction * _moveSpeed;
        _rigidbody.velocity = new(distance * PhysicsFactor * Time.deltaTime, _rigidbody.velocity.y);
            if (OnGround())
    }
}