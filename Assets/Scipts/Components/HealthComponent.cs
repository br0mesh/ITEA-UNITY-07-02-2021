using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scipts.Components
{
    public class HealthComponent : MonoBehaviour
    {
        [SerializeField] private int health;

        bool canGetDamage = true;
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
            if (canGetDamage == false)
            {
                return;
            }
            health -= attackComponent.Damage;

            StartCoroutine(GotDamage());

            if (health <= 0)
            {
                isDead = true;
                health = 0;
                OnDead?.Invoke();
                StartCoroutine(Death());
                
            }

            OnHealthChanged?.Invoke(health);
            
        }

        IEnumerator GotDamage()
        {
            canGetDamage = false;
            yield return new WaitForSeconds(1f);
            canGetDamage = true;
        }

        IEnumerator Death()
        {
            yield return new WaitForSeconds(0.5f);
            gameObject.SetActive(false);
        }
    }
    
}
