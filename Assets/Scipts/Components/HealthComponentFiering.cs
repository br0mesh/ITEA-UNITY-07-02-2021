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

        [SerializeField] private float timeBetweenDamage;
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

            //StartCoroutine(waiter());
        }

        IEnumerator waiter()
        {
            allowDamage = false;
            yield return new WaitForSeconds(timeBetweenDamage);
            allowDamage = true;
        }
        public void ProcessDamage(AttackComponent3 attackComponent)
        {
            if(!allowDamage)
            {
                return;
            }

            health -= attackComponent.Damage;
            Debug.Log("Not start coturine");
            waiter();
            Debug.Log("Not start coturine - FINISHED");


            if (health <= 0)
            {
                isDead = true;
                health = 0;
                OnDead?.Invoke();
            }

            OnHealthChanged?.Invoke(health);
            Debug.Log("start coturine");
            StartCoroutine(waiter());
        }
    }
   
   
}


