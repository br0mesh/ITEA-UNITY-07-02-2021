using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scipts.Components.InputComponents
{
    public abstract class CharacterBaseInputComponent : MonoBehaviour
    {
        public Action<float> OnCharacterMove { get; set; }
        public Action OnCharacterIdle { get; set; }
        public Action OnCharacterAttack { get; set; }
        public Action<bool> OnCharacterBlock { get; set; }
    }
}
