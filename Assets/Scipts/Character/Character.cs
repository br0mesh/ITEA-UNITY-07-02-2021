using Assets.Scipts.Building;
using Assets.Scipts.ResourceManage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scipts.Character
{
    public class Character: MonoBehaviour
    {
        [SerializeField] private ResourceManager resourceManager;
        [SerializeField] private BuildingPlace buildingPlace;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            var buildingPlace = collision.gameObject.GetComponent<BuildingPlace>();

            if(buildingPlace != null)
            {
                this.buildingPlace = buildingPlace;
            }
        }
        private void OnTriggerExit2D(Collider2D collision)
        {
            var buildingPlace = collision.gameObject.GetComponent<BuildingPlace>();

            if (buildingPlace != null)
            {
                this.buildingPlace = null;
            }
        }

        private void Update()
        {
            if(Input.GetKeyDown(KeyCode.B))
            {
                if(buildingPlace != null)
                {
                    BuildBuilding();
                }
            }
        }
        public void BuildBuilding()
        {
            if (resourceManager.Money < buildingPlace.GetUpgradePrice())
            {
                Debug.LogError("Incorrect money amount");
                return;
            }

            resourceManager.Money -= buildingPlace.GetUpgradePrice();

            buildingPlace.Build();
        }
    }
}
