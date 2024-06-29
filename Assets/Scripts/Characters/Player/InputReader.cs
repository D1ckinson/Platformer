using UnityEngine;

public class InputReader
{
    private const string Horizontal = nameof(Horizontal);

    private KeyCode _jumpKey = KeyCode.Space;

    public float Direction => Input.GetAxis(Horizontal);
    public bool IsJump => Input.GetKey(_jumpKey);    
}
