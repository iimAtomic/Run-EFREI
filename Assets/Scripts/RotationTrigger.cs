using UnityEngine;

public class RotationTrigger : MonoBehaviour
{
    public bool rotateLeft; // Set this to true for 90° left rotation, false for 90° right rotation
    public Transform cameraTransform; // Reference to the camera Transform

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
        print("Trigger entered.");
        // Check if the object entering the trigger is the player
        if (other.CompareTag("Player"))
        {
            print("Player entered the trigger.");
            // Determine the rotation angle (90° left or right)
            float rotationAngle = rotateLeft ? -90f : 90f;

            // Rotate the player
            other.transform.Rotate(0, rotationAngle, 0);

            // Rotate the camera
            if (cameraTransform != null)
            {
                cameraTransform.Rotate(0, rotationAngle, 0);
            }
        }
    }
}
