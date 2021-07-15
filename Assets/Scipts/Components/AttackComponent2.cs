using System;
using UnityEngine;

namespace Assets.Scipts.Components
{
    public class AttackComponent2 : MonoBehaviour
    {
        [SerializeField] private int energyLeak;
        public int EnergyLeak { get => energyLeak; }

        public Action<HealthComponent2> OnEnergyLeakDone;
        public void ApplyEnergyLeak(HealthComponent2 healthComponent)
        {
            healthComponent.ProcessEnergyLeak(this);

            OnEnergyLeakDone?.Invoke(healthComponent);
        }

    }
}

