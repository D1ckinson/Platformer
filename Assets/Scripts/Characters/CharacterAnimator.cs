using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class CharacterAnimator : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    private readonly int XSpeed = Animator.StringToHash("XSpeed");
    private readonly int YSpeed = Animator.StringToHash("YSpeed");
    private readonly int InIdle = Animator.StringToHash("InIdle");

    private Rigidbody2D _rigidbody;

    private void Awake() =>
        _rigidbody = GetComponent<Rigidbody2D>();

    private void Update()
    {
        bool inIdle = _rigidbody.velocity.x == 0;

        _animator.SetBool(InIdle, inIdle);
        _animator.SetFloat(XSpeed, _rigidbody.velocity.x);
        _animator.SetFloat(YSpeed, _rigidbody.velocity.y);
    }    
}
