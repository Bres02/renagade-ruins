using Cinemachine;
using KBCore.Refs;
using UnityEngine;


namespace ReagadeRuins {
    public class PlayerController : ValidatedMonoBehaviour
    {
        [Header("References")]
        [SerializeField, Self] CharacterController controller;
        [SerializeField, Anywhere] Animator animator;
        [SerializeField, Anywhere] CinemachineFreeLook freeLookVCam;
        [SerializeField, Anywhere] InputReader input;

        [Header("Settings")]
        [SerializeField] float moveSpeed = 6f;
        [SerializeField] float rotationSpeed = 15f;
        [SerializeField] float smoothTime = 0.2f;

        Transform mainCam;

        float currentSpeed;
        float velocity;

        void Awake()
        {
            mainCam = Camera.main.transform;
            // Sets the freelookcam to follow the player object
            freeLookVCam.Follow = transform;
            // Sets the freelookcam to look at the player object
            freeLookVCam.LookAt = transform;
            // Should the player be teleported or moved unexpectedly, the camera will also adjust its position
            freeLookVCam.OnTargetObjectWarped(transform, transform.position - freeLookVCam.transform.position - Vector3.forward);
        }

        void Update()
        {
            HandleMovement();
            //UpdateAnimator();
        }

        void HandleMovement()
        {
            var movementDirection = new Vector3(input.Direction.x, 0f, input.Direction.y).normalized;
            // Rotate movement direction to match camera rotation
            var adjustedDirection = Quaternion.AngleAxis(mainCam.eulerAngles.y, Vector3.up) * movementDirection;

            if (adjustedDirection.magnitude > 0f)
            {
                // Adjust rotation to match movement direction
                var targetRotation = Quaternion.LookRotation(adjustedDirection);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
                transform.LookAt(transform.position + adjustedDirection);

                // Move player
                var adjustedMovement = adjustedDirection * (moveSpeed * Time.deltaTime);
                controller.Move(adjustedMovement);

                SmoothSpeed(adjustedMovement.magnitude);
            } else
            {
                SmoothSpeed(0f);
            }
        }

        void SmoothSpeed(float value) {
            currentSpeed = Mathf.SmoothDamp(currentSpeed, value, ref velocity, smoothTime);
        }

    }

}
