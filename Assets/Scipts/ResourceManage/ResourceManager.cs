using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scipts.ResourceManage
{
    public class ResourceManager : MonoBehaviour
    {
        [SerializeField] private int money;

        public Action OnMoneyChanged;

        public int Money
        {
            get { return money; }
            set
            {
                money = value;
                OnMoneyChanged?.Invoke();
            }
        }
    }
}
