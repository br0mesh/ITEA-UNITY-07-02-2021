using Assets.Scipts.SkillTree.SkillPowerUp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scipts.SkillTree.Graph
{
    [CreateAssetMenu(fileName = "AbilityNode", menuName = "ScriptableObjects/Graph/AbilityNode")]

    public class AbilityNode : Node
    {
        public BaseScriptableAbilityData abilityData;
    }
}
