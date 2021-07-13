using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scipts.Resources
{
    public enum ResourceType
    {
        Money, Food, wood
    }
    [CreateAssetMenu(fileName = "Resource", menuName = "ScriptableObjects/Resource", order = 1)]
    public class ResourceScriptableObject : ScriptableObject
    {
        public ResourceType Type;
        public string Name;
        public Texture2D Image;
    }

    [Serializable]
    public class ResourceContainer
    {
        public ResourceType type;
        public BaseResource resource;
    }
}
