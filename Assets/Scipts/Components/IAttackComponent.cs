using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scipts.Components
{
    public interface IAttackComponent
    {
        int Damage{ get; }
        Action<HealthComponent> OnDamageDone { get; set; }
        void ApplyDamage(HealthComponent healthComponent);
        void ApplyDamage(HealthComponent[] healthComponents);
    }
}
