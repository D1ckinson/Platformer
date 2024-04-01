using UnityEngine;

public class CharacterAnimator : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    private readonly int OnGround = Animator.StringToHash("OnGround");
    private readonly int XSpeed = Animator.StringToHash("XSpeed");
    private readonly int YSpeed = Animator.StringToHash("YSpeed");
    private readonly int InIdle = Animator.StringToHash("InIdle");

    public void SetSpeed(Vector2 vector2)
    {
        bool inIdle = vector2.x == 0;

        _animator.SetBool(InIdle, inIdle);
        _animator.SetFloat(XSpeed, vector2.x);
        _animator.SetFloat(YSpeed, vector2.y);
    }

    public void SetOnGround(bool onGround) =>
        _animator.SetBool(OnGround, onGround);
}
