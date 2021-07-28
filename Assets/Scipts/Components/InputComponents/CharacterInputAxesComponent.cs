using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scipts.Components.InputComponents
{
    public class CharacterInputAxesComponent : CharacterBaseInputComponent
    {
        public override Action<float> OnCharacterMove { get; set; }
        public override Action OnCharacterIdle { get; set; }

        void Update()
        {
            float moveInput = Input.GetAxisRaw("Horizontal");
            moveInput *= Time.deltaTime;

            if (moveInput != 0)
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