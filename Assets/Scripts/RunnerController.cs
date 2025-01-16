using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class RunnerController : MonoBehaviour
{
    public float laneSize;
    public float speed;
    public float jumpForce;
    //True = gauche, false = droite
    public bool lane = false;

    public Rigidbody rigidBody;
    public GameObject playerVisual;
    public LayerMask groundLayer;

    Animator animator;


    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        ///Movement forward
        this.transform.position += this.transform.forward * (speed * Time.deltaTime);
        animator.SetBool("isJumping", false);

        ///Lane switching
        if (lane == true)
        {
            playerVisual.transform.position = this.transform.position - this.transform.right * laneSize;
        }
        else
        {
            playerVisual.transform.position = this.transform.position + this.transform.right * laneSize;
        }
        
        if (Input.GetKeyDown(KeyCode.A) && lane == false)
        {
            changeLane();
        }
        else if (Input.GetKeyDown(KeyCode.D) && lane == true)
        {
            changeLane();
        }
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            jump();
            animator.SetBool("isJumping", true);
        }
    }
    bool CheckIfGrounded()
    {
        // Vérifie si le personnage touche le sol
        return Physics.Raycast(transform.position, Vector3.down, 1.1f, groundLayer);
    }

    void changeLane()
    {
        lane = !lane;
    }
    void jump()
    {
        rigidBody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }

    void OnTriggerEnter(Collider other)
    {
        // Vérifie si l'objet touché a le tag "Obstacle"
        if (other.CompareTag("Obstacle"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            // Vérifie si le joueur touche l'obstacle par le dessus
            if (IsCollisionFromAbove(collision))
            {
                // La partie continue si le joueur saute sur l'obstacle
                Debug.Log("Sauté sur un obstacle !");
            }
            else
            {
                // Si le joueur fonce dans l'obstacle, c'est Game Over
                Debug.Log("Collision avec un obstacle de face !");
            }
        }
    }

    private bool IsCollisionFromAbove(Collision collision)
    {
        // Détecte si le contact principal est par le dessus
        foreach (ContactPoint contact in collision.contacts)
        {
            if (contact.normal.y > 0.2f) // La normale pointe vers le haut (contact par le dessus)
            {
                return true;
            }
        }
        return false;
    }

}
