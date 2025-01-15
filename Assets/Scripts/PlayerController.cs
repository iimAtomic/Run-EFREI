using UnityEngine;
using DG.Tweening;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    public float laneDistance; // Distance between lanes
    [SerializeField]
    public float initialPlayerSpeed;
    private int currentLane = 1; // -1 is left lane, 1 is right lane
    private Vector3 targetPosition;
    public float duration;
    public bool animCompleted = true;

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

        if (Input.GetKeyDown(KeyCode.A) && currentLane == 1 && animCompleted == true)
        {
            animCompleted = false;
            currentLane = -1;
            UpdateTargetPosition();
        }
        else if (Input.GetKeyDown(KeyCode.D) && currentLane == -1 && animCompleted == true)
        {
            animCompleted = false;
            currentLane = 1;
            UpdateTargetPosition();
        }
        //this.transform.DOLocalMoveZ(targetPosition.z, duration);
        //this.transform.DOMove(this.transform.position + transform.forward * initialPlayerSpeed * Time.deltaTime, Time.deltaTime);

        this.transform.DOMove(targetPosition, duration).OnComplete(() =>
        {
            animCompleted = true;
        });
    }

    // Update the target position based on the current lane
    void UpdateTargetPosition()
    {
        // Update the target position for lane change using Transform.right
        targetPosition = transform.position + transform.right * (currentLane * laneDistance);
        float movement = currentLane * laneDistance;
        // Move the player to the target position
        /*
        this.transform.DOMove(this.transform.position + transform.right * movement, duration).OnComplete(() =>
        {
            animCompleted = true;
        });
        */
    }

}
