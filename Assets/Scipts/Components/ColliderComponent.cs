using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scipts.Components
{
    public class ColliderComponent : MonoBehaviour
    {
        [SerializeField] private List<Collider2D> collidersInRadius;


        public List<Collider2D> CollidersInRadius { get => collidersInRadius; }

        public Action<Collider2D> OnTriggerEnter;
        public Action<Collider2D> OnTriggerExit;


       

        private void OnTriggerEnter2D(Collider2D collision)
        {
            collidersInRadius.Add(collision);
            OnTriggerEnter?.Invoke(collision);
        }
        private void OnTriggerExit2D(Collider2D collision)
        {
            collidersInRadius.Remove(collision);
            OnTriggerExit?.Invoke(collision);
        }
    }
}
