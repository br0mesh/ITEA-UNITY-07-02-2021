using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scipts.Components
{
    public interface IAttackComponent
    {
        public int Damage{ get; }
        public Action<HealthComponent> OnDamageDone { get; set; }
        public void ApplyDamage(HealthComponent healthComponent);
    }
}
