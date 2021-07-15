using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Assets.Scipts.Components
{
    public class HealthComponentFiering : MonoBehaviour
    {
        [SerializeField] private int health;
        private bool allowDamage = true;
        public int Health
        {
            get
            {
                return health;
            }
            private set => health = value;
        }

        [SerializeField] private bool isDead;
        public bool IsDead { get => isDead; }

        public Action<int> OnHealthChanged { get; }
        public Action OnDead { get; }


        private void Start()
        {
            StartCoroutine(waiter());
        }

        IEnumerator waiter()
        {
            
            yield return new WaitForSeconds(5);
        }
        public void ProcessDamage(AttackComponent3 attackComponent)
        {
            health -= attackComponent.Damage;
            waiter();
         
            if (health <= 0)
            {
                isDead = true;
                health = 0;
                OnDead?.Invoke();
            }

            OnHealthChanged?.Invoke(health);
            
        }
    }
   
   
}


