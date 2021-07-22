using Assets.Scipts.Components;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackComponent2 : AttackComponent
{
    [SerializeField] private int enhancedDamage;
    public int EnhancedDamage
    {
        get => enhancedDamage;
    }

    public Action<HealthComponent2> OnEnhancedDamageDone;
    public void ApplyDamage(HealthComponent2 healthComponent)
    {
        healthComponent.ProcessEnhancedDamage(this);

        OnEnhancedDamageDone?.Invoke(healthComponent);
    }
}
