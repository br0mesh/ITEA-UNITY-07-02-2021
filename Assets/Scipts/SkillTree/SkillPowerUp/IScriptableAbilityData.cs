using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scipts.SkillTree.SkillPowerUp
{
   public interface IScriptableAbilityData
    {
        Sprite Sprite { get; }
        string Name { get; }
        string Description { get; }
    }
}
