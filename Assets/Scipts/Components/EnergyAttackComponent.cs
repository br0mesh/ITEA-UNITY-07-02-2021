using System;
using UnityEngine;

namespace Assets.Scipts.Components
{
    public class EnergyAttackComponent : AttackComponent
    {

        [SerializeField] private int energyDamage;
        public int EnergyDamage { get => energyDamage; }

        public Action<EnergyComponent> OnEnergyDamageDone { get; set; }

        public void ApplyEnergyDamage(EnergyComponent energyComponent)
        {
            energyComponent.ProcessEnergyDamage(this);

            OnDamageDone?.Invoke(energyComponent);
        }
    }
}