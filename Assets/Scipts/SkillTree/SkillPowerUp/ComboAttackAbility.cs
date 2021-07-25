using Assets.Scipts.Components;
using System;
using System.Collections;
using UnityEngine;

namespace Assets.Scipts.SkillTree.SkillPowerUp
{
    [CreateAssetMenu(fileName = "ComboAttackAbility", menuName = "ScriptableObjects/Ability/ComboAttack", order = 2)]
    class ComboAttackAbility : ScriptableObject, IHealhtAbility
    {
        [SerializeField] private int startComboAttack;
        [SerializeField] private int powerAttack;

        private AttackComponent attackComponent;

        public bool CanUseAbility(HealthComponent healthComponent)
        {
            return healthComponent.Health > 0;
        }

        public IEnumerator UseAbility(HealthComponent healthComponent)
        {
            return StartAttack(startComboAttack, healthComponent);
        }

        private IEnumerator StartAttack(int startComboAttack, HealthComponent healthComponent)
        {
            while (healthComponent.Health != 0)
            {
                yield return new WaitForSeconds(startComboAttack);
                attackComponent.Damage = powerAttack;
            }
            Debug.Log("The attack works");
        }

        public int Damage => powerAttack;

        public Action<HealthComponent> OnDamageDone { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public void ApplyDamage(HealthComponent healthComponent)
        {
            throw new NotImplementedException();
        }
    }
}
