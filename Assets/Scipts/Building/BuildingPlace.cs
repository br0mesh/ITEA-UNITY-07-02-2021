using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scipts.Building
{
    public class BuildingPlace : MonoBehaviour
    {
        [SerializeField] private BaseBuilding buildingPrefab;

        [SerializeField] private BaseBuilding building;
        public BaseBuilding Building { get => building; }
        private int build = 0;

        [SerializeField] private GameObject UIHolder;

        [ContextMenu("Build")]
        public void Build()
        {
            if (building != null)
            {
                building.DestroyBuiling();
            }
            building = Instantiate(buildingPrefab.gameObject, transform).GetComponent<BaseBuilding>();
            building.Build();
            buildingPrefab = building.BuildingToUpgrade[build];
            build++;
        }
        public int GetUpgradePrice()
        {
            return buildingPrefab.Price;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.TryGetComponent<Character.Character>(out var character))
            {
                SetActiveUI(true);
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.gameObject.TryGetComponent<Character.Character>(out var character))
            {
                SetActiveUI(false);
            }
        }

        private void SetActiveUI(bool value)
        {
            UIHolder.SetActive(value);
        }
    }
}
