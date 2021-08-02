using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scipts.Components
{
    public class AttackComponent : MonoBehaviour, IAttackComponent
    {
        [SerializeField] private int damage;
        public int Damage { get => damage; }
        public Action<HealthComponent> OnDamageDone { get; set; }
        public void ApplyDamage(HealthComponent healthComponent)
        {
            Debug.Log("AttackComponent");
            healthComponent.ProcessDamage(this);

            OnDamageDone?.Invoke(healthComponent);
        }
        public void ApplyDamage(HealthComponent[] healthComponents)
        {
            for (int i = 0; i < healthComponents.Length; i++)
            {
                healthComponents[i].ProcessDamage(this);
            }
        }
    }
}
