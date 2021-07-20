using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scipts.Components
{
    public class EnergyComponent : HealthComponent
    {
        [SerializeField] private int energy;
        public int Energy { get => energy; }

        public void ProcessEnergyDamage(EnergyAttackComponent energyAttackComponent)
        {
            energy -= energyAttackComponent.EnergyDamage;
            if ( energy <= 0)
            {
                energy = 0;
            }
        }
    }
}

