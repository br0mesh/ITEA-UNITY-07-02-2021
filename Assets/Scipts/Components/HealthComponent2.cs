using System;
using UnityEngine;

namespace Assets.Scipts.Components
{
    public class HealthComponent2 : HealthComponent
    {
        [SerializeField] private int energy;
        public int Energy
        {
            get
            {
                return energy;
            }
            private set
            {
                energy = value;
            }
        }
        [SerializeField] private bool isRun;
        public bool IsRun { get => isRun; }

        public Action<int> OnEnergyChanged { get; }
        public Action OnRun { get; }

        public void ProcessEnergyLeak(AttackComponent2 attackComponent)
        {
            energy -= attackComponent.EnergyLeak;

            if (energy <= 0)
            {
                isRun = true;
                energy = 0;
                OnRun?.Invoke();
            }

            OnEnergyChanged?.Invoke(energy);
        }
    }
}

