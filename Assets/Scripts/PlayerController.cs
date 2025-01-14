using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    public float laneDistance; // Distance between lanes
    [SerializeField]
    public float initialPlayerSpeed;
    private int currentLane = 1; // -1 is left lane, 1 is right lane
    private Vector3 targetPosition;

    // Start is called before the first frame update
    void Start()
    {
        // Set initial target position
        targetPosition = this.gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // Update target position to include forward movement
        targetPosition += transform.forward * initialPlayerSpeed * Time.deltaTime;

        // Check for lane change input
                 
        if (Input.GetKeyDown(KeyCode.A) && currentLane == 1)
        {
            currentLane = -1;
            UpdateTargetPosition();
        }
        else if (Input.GetKeyDown(KeyCode.D) && currentLane == -1)
        {
            currentLane = 1;
            UpdateTargetPosition();
        }

        // Move the player to the target position
        this.gameObject.transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * 10f);
    }

    // Update the target position based on the current lane
    void UpdateTargetPosition()
    {
        // Update the target position for lane change using Transform.right
        targetPosition = transform.position + transform.right * (currentLane * laneDistance);
    }

}
