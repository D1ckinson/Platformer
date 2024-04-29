using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealButton : HealthInteractButton
{
    [SerializeField] private Medkit _medkit;

    public override void Interact() =>
        Health.Heal(_medkit);
}
