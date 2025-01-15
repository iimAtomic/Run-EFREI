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


    public float jumpForce = 5f;    // Force du saut
    public LayerMask groundLayer;  // Layer pour détecter le sol
    public float runSpeed = 5f;    // Vitesse d'avancement vertical
    public float moveSpeed = 5f;   // Vitesse de déplacement horizontal (gauche/droite)

    private Rigidbody rb;
    private bool isGrounded;

    // Start is called before the first frame update
    void Start()
    {
        // Set initial target position
        targetPosition = this.gameObject.transform.position;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = CheckIfGrounded();
        float horizontalInput = Input.GetAxis("Horizontal");
            
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
        // Appliquer le saut si au sol et touche "Espace" pressée
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            print("Jumping");
            Jump();
        }
        //this.transform.DOLocalMoveZ(targetPosition.z, duration);
        //this.transform.DOMove(this.transform.position + transform.forward * initialPlayerSpeed * Time.deltaTime, Time.deltaTime);
        
        rb.linearVelocity = new Vector3(horizontalInput * moveSpeed, rb.linearVelocity.y, runSpeed);
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

    void Jump()
    {
        // Appliquer une force vers le haut pour faire sauter le personnage
        rb.linearVelocity = new Vector3(rb.linearVelocity.x, jumpForce, rb.linearVelocity.z);
    }
    bool CheckIfGrounded()
    {
        // Vérifie si le personnage touche le sol
        return Physics.Raycast(transform.position, Vector3.down, 1.1f, groundLayer);
    }

}
