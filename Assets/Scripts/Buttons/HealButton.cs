using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealButton : HealthInteractButton
{
    [SerializeField] private Medkit _medkit;

    public override void Interact() =>
        _health.Heal(_medkit);
}
