using UnityEngine;
using Input.Provider;
using Input;

namespace Camera.Movement
{
    [RequireComponent(typeof(CameraMotor))]
    [RequireComponent(typeof(PlayerInputProvider))]
    public class CameraController : MonoBehaviour
    {
        private IInputProvider<PlayerInputFrame> m_inputProvider;
        private CameraMotor m_cameraMotor;

        void Awake()
        {
            m_inputProvider = GetComponent<IInputProvider<PlayerInputFrame>>();
            m_cameraMotor = GetComponent<CameraMotor>();

            Debug.Assert(m_inputProvider != null, $"No {nameof(PlayerInputProvider)} found on {gameObject.name}.");
            Debug.Assert(m_cameraMotor != null, $"No {nameof(CameraMotor)} found on {gameObject.name}.");
        }

        void Update()
        {
            PlayerInputFrame inputFrame = m_inputProvider.GetInputFrame();
            m_cameraMotor.Tick(inputFrame);
            m_inputProvider.ConsumeInput();
        }
    }
}

