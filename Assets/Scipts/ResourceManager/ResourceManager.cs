using Assets.Scipts.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scipts.ResourceManage
{
    public class ResourceManager : Singleton<ResourceManager>
    {
        [SerializeField] private List<ResourceContainer> resurces = new List<ResourceContainer>();

        public BaseResource GetResource(ResourceType resourceType)
        {
            return resurces.Find((resource) => resource.type == resourceType)?.resource;
        }
        public void AddResource(ResourceType type, int value)
        {
            ResourceContainer resource = resurces.Find((resource) => resource.type == type);

            if (resource != null)
            {
                resource.resource.Value += value;
            }
        }
    }
}
