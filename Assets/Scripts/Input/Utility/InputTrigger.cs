using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Input.Utility
{
    public struct InputTrigger
    {
        public bool Pressed;
        public bool Held;
        public bool Released;

        public InputTrigger LoadFromInputAction(InputAction action)
        {
            Pressed |= action.WasPressedThisFrame();

            Held = action.IsPressed();

            Released |= action.WasReleasedThisFrame();

            return this;
        }

        public void Consume()
        {
            Pressed = false;
            Released = false;
        }
    }
}
