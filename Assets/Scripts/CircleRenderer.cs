using UnityEngine;

public class CircleRenderer : MonoBehaviour
{
    [SerializeField] private Texture2D _texture;
    [SerializeField] private Material _material;
    [Range(2, 512)][SerializeField] private int _resolution = 128;
    [SerializeField] private float _outRadius;
    //[SerializeField] private float _inRadius

    private float _pixelOffset = 0.5f;
    private Color _circle = Color.white;
    private Color _transparent = new(0, 0, 0, 0);
    private float _offset;
    private float _offsetDivider = 2f;

    private void OnValidate()
    {
        _offset = _resolution / _offsetDivider;
        _texture = new(_resolution, _resolution)
        {
            wrapMode = TextureWrapMode.Clamp
        };

        GetComponent<Renderer>().sharedMaterial.mainTexture = _texture;

        float step = 1f / _resolution - _offset;
        float rSquare = Mathf.Sqrt(_outRadius);

        for (int y = 0; y < _resolution; y++)
        {
            for (int x = 0; x < _resolution; x++)
            {
                float result = CalculateCircleSquaresSum(x, y, step);

                _texture.SetPixel(x, y, SetColor(result, rSquare));
            }
        }

        _texture.Apply();
    }

    private float CalculateCircleSquaresSum(float x, float y, float step) =>
        Mathf.Sqrt((x + _pixelOffset) * step) + Mathf.Sqrt((y + _pixelOffset) * step);

    private Color SetColor(float result, float rSquare) =>
        result > rSquare ? _circle : _transparent;
}
