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
        public abstract Action<float> OnCharacterMove { get; set; }
        public abstract Action OnCharacterIdle { get; set; }
    }
}
