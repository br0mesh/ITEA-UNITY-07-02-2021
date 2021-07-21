using Assets.Scipts.Components;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scipts.SkillTree.SkillPowerUp
{
    public interface IAbility
    {
        bool CanUseAbility();
        void UseAbility();
    }
    public interface IHealhtAbility : IAttackComponent
    {
        IEnumerator UseAbility(HealthComponent healthComponent);

        bool CanUseAbility(HealthComponent healthComponent);
    }
}
