using Assets.Scipts.Components;
using Assets.Scipts.SkillTree.SkillPowerUp;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "ShieldAbility", menuName = "ScriptableObjects/Ability/Shield", order = 3)]
public class ShieldAbility : ScriptableObject, IHealhtAbility
{
    [SerializeField] private int startShield;
    [SerializeField] private int timeOfAction;

    private AttackComponent attackComponent;

    public bool CanUseAbility(HealthComponent healthComponent)
    {
        return healthComponent.Health > 0;
    }

    public IEnumerator UseAbility(HealthComponent healthComponent)
    {
        return StartShield(startShield, timeOfAction, healthComponent);
    }

    private IEnumerator StartShield(int startShield, int timeOfAction, HealthComponent healthComponent)
    {
        while (healthComponent.Health != 0)
        {
            yield return new WaitForSeconds(startShield);
            attackComponent.Damage = 0;
            yield return new WaitForSeconds(timeOfAction);
        }

    }

    public int Damage => throw new NotImplementedException();
    public Action<HealthComponent> OnDamageDone { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

    public void ApplyDamage(HealthComponent healthComponent)
    {
        throw new NotImplementedException();
    }
}
