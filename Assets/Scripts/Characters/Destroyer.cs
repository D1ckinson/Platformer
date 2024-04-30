using UnityEngine;

public class Destroyer : MonoBehaviour
{
    [SerializeField] private Health _health;

    private void OnEnable() =>
        _health.ValueOver += Destroy;

    private void OnDisable() =>
        _health.ValueOver -= Destroy;

    private void Destroy() =>
        Destroy(_health.gameObject);
}
