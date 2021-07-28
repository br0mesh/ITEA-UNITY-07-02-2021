using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scipts.Components.InputComponents
{
    public class CharacterInputKeyComponent : CharacterBaseInputComponent
    {
        public override Action<float> OnCharacterMove { get; set; }
        public override Action OnCharacterIdle { get; set; }

        void Update()
        {
            float moveInput = 0f;

            if (Input.GetKey(KeyCode.A))
            {
                moveInput = -1;
            }
            if (Input.GetKey(KeyCode.D))
            {
                moveInput = 1;
            }

            moveInput *= Time.deltaTime;

            if(moveInput != 0)
            {
                OnCharacterMove?.Invoke(moveInput);
            }
            else
            {
                OnCharacterIdle?.Invoke();
            }
        }
    }
}
