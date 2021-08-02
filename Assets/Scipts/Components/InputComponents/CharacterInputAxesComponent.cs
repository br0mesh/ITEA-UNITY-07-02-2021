using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scipts.Components.InputComponents
{
    public class CharacterInputAxesComponent : CharacterBaseInputComponent
    {
        void Update()
        {
            float moveInput = Input.GetAxisRaw("Horizontal");
            //moveInput *= Time.deltaTime;

            if (moveInput != 0f)
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