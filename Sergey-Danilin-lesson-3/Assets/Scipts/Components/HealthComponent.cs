using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scipts.Components
{
    public class HealthComponent : MonoBehaviour
    {
        [SerializeField] private int health;
        [SerializeField] private int kd = 2;
        private bool allowDamage = true;
        public int Health
        {
            get
            {
                return health;
            }
            private set
            {
                health = value;
            }
        }

        [SerializeField] private bool isDead;
        public bool IsDead { get => isDead; }

        public Action<int> OnHealthChanged { get; }
        public Action OnDead { get; }

        public void ProcessDamage(AttackComponent attackComponent)
        {
            if (!allowDamage)
            {
                return;
            }
            health -= attackComponent.Damage;

            if (health <= 0)
            {
                isDead = true;
                health = 0;
                OnDead?.Invoke();
            }
            if (isDead == true)
            {
                Destroy(gameObject);
            }

            OnHealthChanged?.Invoke(health);
            StartCoroutine(DamageKD());

        }

        IEnumerator DamageKD()
        {
            allowDamage = false;
            yield return new WaitForSeconds(kd);
            allowDamage = true;
        }
    }
}
