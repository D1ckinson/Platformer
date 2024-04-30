using UnityEngine;
using UnityEngine.Events;

public class InputReader : MonoBehaviour
{
    private const string Horizontal = nameof(Horizontal);
    private const string Vertical = nameof(Vertical);

    public UnityAction<float, bool> InputReceived;
    private KeyCode _jumpKey = KeyCode.Space;

    private void Update()
    {
        bool isVerticalKeyDown = Input.GetKey(_jumpKey);
        float axis = Input.GetAxis(Horizontal);

        InputReceived?.Invoke(axis, isVerticalKeyDown);
    }
}
