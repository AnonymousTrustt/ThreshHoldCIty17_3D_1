using UnityEngine;
using Unity.Cinemachine;
using Input;
using Input.Provider;

namespace Camera.Movement
{
    public class CameraMotor : MonoBehaviour, IMotor<PlayerInputFrame>
    {
        [SerializeField] CinemachineCamera defaultCamera;
        [SerializeField] Transform cameraTransform;
        [SerializeField] float panSpeed = 5f;
        [SerializeField] float zoomSpeed = 10f;

        public PlayerInputFrame currentInputFrame;

        void Awake()
        {
            if (cameraTransform == null)
            {
                cameraTransform = transform;
            }
        }

        public void Tick(PlayerInputFrame inputFrame)
        {
            currentInputFrame = inputFrame;
            PanCamera(inputFrame.MovementDirection);
            // ZoomCamera(inputFrame.ZoomValue);
        }

        private void PanCamera(Vector2 movementDirection)
        {
            if (movementDirection == Vector2.zero) return;

            Vector3 move = new Vector3(movementDirection.x, 0f, movementDirection.y);

            Vector3 forward = cameraTransform.forward;
            Vector3 right = cameraTransform.right;
            forward.y = 0f;
            right.y = 0f;

            Vector3 worldMove = (forward.normalized * move.z) + (right.normalized * move.x);

            Vector3 newPos = cameraTransform.position + worldMove * panSpeed * Time.deltaTime;

            cameraTransform.position = newPos;
        }

        // private void ZoomCamera(float ZoomValue)
        // {
        //     if (ZoomValue == 0f) return;

        //     float zoomAmount = ZoomValue;

        //     defaultCamera.Lens.FieldOfView += zoomAmount * zoomSpeed * Time.deltaTime;
        //     defaultCamera.Lens.FieldOfView = Mathf.Clamp(defaultCamera.Lens.FieldOfView, 40f, 70f);
        // }

    }
}
