using System;
using UnityEngine;

namespace Assets.Scipts.Components
{
    public class AttackComponent3 : AttackComponent2
    {
        [SerializeField] private int damageTemporary;
        public int DamageTemporary { get => damageTemporary; }

        public Action<HealthComponentFiering> OnEnergyLeakDone;
        public void ApplyTemporaryDamage(HealthComponentFiering healthComponent)
        {
            healthComponent.ProcessDamage(this);

            OnEnergyLeakDone?.Invoke(healthComponent);
        }

    }
}

