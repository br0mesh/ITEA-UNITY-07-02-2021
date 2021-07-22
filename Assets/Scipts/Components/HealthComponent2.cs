using Assets.Scipts.Components;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthComponent2 : HealthComponent
{
    protected bool possibilityOfDamage = true;
    public bool PossibilityOfDamage
    {
        get => possibilityOfDamage;
    }
    [SerializeField] private float timeBetweenDamage;

    IEnumerator Waiter()
    {
        possibilityOfDamage = false;
        yield return new WaitForSeconds(timeBetweenDamage);
        possibilityOfDamage = true;
    }

    public void ProcessEnhancedDamage(AttackComponent2 attackComponent)
    {
        if (!possibilityOfDamage)
        {
            return;
        }
        Health -= attackComponent.EnhancedDamage;

        if (Health <= 0)
        {
            IsDead = true;
            Health = 0;
            OnDead?.Invoke();
            Destroy(gameObject);
        }

        OnHealthChanged?.Invoke(Health);
        StartCoroutine(Waiter());
    }
}
