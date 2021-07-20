using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scipts.Components
{
    public class AttackComponent : MonoBehaviour
    {
        [SerializeField] private int damage;
        public int Damage { get => damage; }

        public Action<HealthComponent> OnDamageDone { get; set; }

        public void ApplyDamage(HealthComponent healthComponent)
        {
            healthComponent.ProcessDamage(this);

            OnDamageDone?.Invoke(healthComponent);
        }
    }
}
