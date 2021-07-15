using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scipts.Components
{
    public class HealthComponent : MonoBehaviour
    {
        [SerializeField] private int health;
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
        }
        
    }
}