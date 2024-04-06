using UnityEngine;

public class Medkit : MonoBehaviour, ICollectable
{
    [field: SerializeField] public float Heal { get; private set; }
}
