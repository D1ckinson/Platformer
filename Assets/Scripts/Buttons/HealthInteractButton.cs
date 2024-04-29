using UnityEngine;

public abstract class HealthInteractButton : MonoBehaviour
{
    [SerializeField] protected Health Health;

    public abstract void Interact();
}
