using System;
using UnityEngine;

namespace Assets.Scipts.Resources
{
    [Serializable]
    public class BaseResource
    {
        [SerializeField] private int value;

        public int Value
        {
            get { return value; }
            set
            {
                this.value = value;
                OnValueChanged?.Invoke();
            }
        }

        [SerializeField] private ResourceScriptableObject data;

        public Action OnValueChanged;
    }
}
