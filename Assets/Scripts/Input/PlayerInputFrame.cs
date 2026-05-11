using Unity.VisualScripting;
using UnityEngine;
using Input.Utility;

namespace Input
{
    public struct PlayerInputFrame : IConsumable
    {
        public Vector2 MovementDirection;

        public InputTrigger Interact;
        public InputTrigger AlternateInteract;

        public float ZoomValue;

        public void Consume()
        {
            Interact.Consume();
            AlternateInteract.Consume();
        }
    }
}