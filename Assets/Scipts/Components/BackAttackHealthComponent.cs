using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scipts.Components
{
    public class BackAttackHealthComponent: MonoBehaviour
    {
        [SerializeField]private int healthback;
        

        public int HealthBack
        {
            get
            {
                return healthback;
            }
            private set
            {
                
            }
        }
        


    }
}
