using UnityEngine;

public class RotationTrigger : MonoBehaviour
{
    public bool rotateLeft; // Set this to true for 90� left rotation, false for 90� right rotation
    public Transform cameraTransform; // Reference to the camera Transform
    private bool hasTriggered = false; // Flag to ensure the trigger only activates once

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }


    private void OnTriggerEnter(Collider other)
    {
        if (hasTriggered) return; // Exit if the trigger has already been activated

        print("Trigger entered.");
        // Check if the object entering the trigger is the player
        if (other.CompareTag("Player"))
        {
            hasTriggered = true; // Set the flag to true to prevent reactivation
            print("Player entered the trigger.");
            // Determine the rotation angle (90� left or right)
            float rotationAngle = rotateLeft ? -90f : 90f;

            // Rotate the player
            other.transform.parent.Rotate(0, rotationAngle, 0);

            // Rotate the camera
            if (cameraTransform != null)
            {
                cameraTransform.Rotate(0, rotationAngle, 0);
            }
        }
    }
}
