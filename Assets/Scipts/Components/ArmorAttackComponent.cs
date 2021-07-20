using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scipts.Components
{
    public class ArmorAttackComponent : AttackComponent , IAttackComponent
    {
        //public int Damage => throw new NotImplementedException();

        //public Action<HealthComponent> OnDamageDone { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public void ApplyDamage(HealthComponent healthComponent)
        {
            Debug.Log("ArmorAttackComponent");
            var armor = healthComponent.gameObject.GetComponent<ArmorComponent>();
            if(armor == null)
            {
                return;
            }
            throw new NotImplementedException();
        }
    }
}
