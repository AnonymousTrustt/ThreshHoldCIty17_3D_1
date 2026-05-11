using UnityEngine;
using Input;
using Input.Provider;
using UnityEngine.InputSystem;

namespace Input.Provider
{
    public class PlayerInputProvider : MonoBehaviour, IInputProvider<PlayerInputFrame>
    {
        private const string k_PlayerMoveKey = "Player/Move";

        private const string k_PlayerInteractKey = "Player/Interact";

        private const string k_PlayerAlternateInteractKey = "Player/AlternateInteract";

        private const string k_PlayerZoomKey = "Player/Zoom";

        [SerializeField] PlayerInput playerInput;

        private InputAction m_playerMoveAction;
        private InputAction m_playerInteractAction;
        private InputAction m_playerAlternateInteractAction;
        private InputAction m_playerZoomAction;

        private PlayerInputFrame m_currentInputFrame;

        void Awake()
        {
            Debug.Assert(playerInput != null, $"PlayerInput component reference is not set on {nameof(PlayerInputProvider)} attached to {gameObject.name}.");
            SetInputs();
        }

        public void SetInputs()
        {
            m_playerMoveAction = playerInput.actions.FindAction(k_PlayerMoveKey);
            m_playerInteractAction = playerInput.actions.FindAction(k_PlayerInteractKey);
            m_playerAlternateInteractAction = playerInput.actions.FindAction(k_PlayerAlternateInteractKey);
            m_playerZoomAction = playerInput.actions.FindAction(k_PlayerZoomKey);
        }

        void Update()
        {
            m_currentInputFrame.MovementDirection = m_playerMoveAction.ReadValue<Vector2>();
            m_currentInputFrame.Interact = m_currentInputFrame.Interact.LoadFromInputAction(m_playerInteractAction);
            m_currentInputFrame.AlternateInteract = m_currentInputFrame.AlternateInteract.LoadFromInputAction(m_playerAlternateInteractAction);
            m_currentInputFrame.ZoomValue = m_playerZoomAction.ReadValue<Vector2>().y;
        }

        public PlayerInputFrame GetInputFrame()
        {
            return m_currentInputFrame;
        }

        public void ConsumeInput()
        {
            m_currentInputFrame.Consume();
        }
    }
}
