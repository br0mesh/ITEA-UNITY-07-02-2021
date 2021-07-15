using System;
using UnityEngine;

namespace Assets.Scipts.Components
{
    public class AttackComponent : MonoBehaviour
    {
        [SerializeField] private int damage;
        public int Damage { get => damage; }

        public Action<HealthComponent> OnDamageDone;
        public void ApplyDamage(HealthComponent healthComponent)
        {
            healthComponent.ProcessDamage(this);

            OnDamageDone?.Invoke(healthComponent);
        }
    }

}
