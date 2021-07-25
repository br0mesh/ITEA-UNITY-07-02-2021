using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scipts.SkillTree.SkillPowerUp
{
    [CreateAssetMenu(fileName = "AbilityData", menuName = "ScriptableObjects/Ability/Data", order = 1)]

    public class BaseScriptableAbilityData : ScriptableObject, IScriptableAbilityData
    {
        [SerializeField] private Sprite sprite;
        public Sprite Sprite { get => sprite; }

        [SerializeField] private string name;
        public string Name { get => name; }

        [SerializeField] private string description;
        public string Description { get => description; }
    }
}
