using Assets.Scipts.Components;
using Assets.Scipts.SkillTree.SkillPowerUp;
using System;
using System.Collections;
using UnityEngine;

[CreateAssetMenu(fileName = "HealthAbility", menuName = "ScriptableObjects/Ability", order = 1)]
public class HealOnLowHealth : ScriptableObject, IHealhtAbility
{
    [SerializeField] private int startHealth;
    [SerializeField] private int healAmount;
    [SerializeField] private float duration;
    [SerializeField] private BaseScriptableAbilityData abilityData;
    #region IHealthAbility
    public IEnumerator UseAbility(HealthComponent healthComponent)
    {
        return StartHeal(healAmount, duration, healthComponent);
    }

    public bool CanUseAbility(HealthComponent healthComponent)
    {
        return healthComponent.Health <= startHealth;
    }

    private IEnumerator StartHeal(int healAmount, float duration, HealthComponent healthComponent)
    {
        while (duration > 0)
        {
            healthComponent.ProcessDamage(this);
            yield return new WaitForSeconds(1f);
            duration -= 1f;
        }
        Debug.Log("Heal works");
    }
    #endregion //IHealthAbility

    #region IAttackComponent
    public int Damage => -healAmount;
    public Action<HealthComponent> OnDamageDone { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public void ApplyDamage(HealthComponent healthComponent)
    {

    }
    public void ApplyDamage(HealthComponent[] healthComponents)
    {

    }
    #endregion //IAttackComponent
}
