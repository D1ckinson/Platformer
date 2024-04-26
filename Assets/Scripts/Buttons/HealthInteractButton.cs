using UnityEngine;

public abstract class HealthInteractButton : MonoBehaviour
{
    [SerializeField] protected Health _health;

    public abstract void Interact();
}
