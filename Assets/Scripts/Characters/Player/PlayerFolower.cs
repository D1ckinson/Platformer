using UnityEngine;

public class PlayerFolower : MonoBehaviour
{
    [SerializeField] private PlayerController _player;

    private Vector3 _offset = new(0, 0, -10);

    private void Update() =>
        transform.position = _player.transform.position + _offset;
}
