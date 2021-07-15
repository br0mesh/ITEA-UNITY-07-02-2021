using System;
using UnityEngine;

namespace Assets.Scipts.Components
{
    public class AttackComponent3 : MonoBehaviour
    {
        [SerializeField] private int damage;
        public int Damage { get => damage; }

        public Action<HealthComponentFiering> OnEnergyLeakDone;
        public void ApplyEnergyLeak(HealthComponentFiering healthComponent)
        {
            healthComponent.ProcessDamage(this);

            OnEnergyLeakDone?.Invoke(healthComponent);
        }

    }
}

