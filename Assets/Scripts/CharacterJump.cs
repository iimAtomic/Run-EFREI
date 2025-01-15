using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterJump : MonoBehaviour
{
    public float jumpForce = 5f;    // Force du saut
    public LayerMask groundLayer;  // Layer pour détecter le sol
    public float runSpeed = 5f;    // Vitesse d'avancement vertical
    public float moveSpeed = 5f;   // Vitesse de déplacement horizontal (gauche/droite)

    private Rigidbody rb;
    private bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        isGrounded = CheckIfGrounded();

        // Déplacement gauche/droite avec les touches A/D ou flèches gauche/droite
        float horizontalInput = Input.GetAxis("Horizontal");

        // Appliquer le saut si au sol et touche "Espace" pressée
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            Jump();
        }

        // Calculer la nouvelle vitesse du personnage
        rb.linearVelocity = new Vector3(horizontalInput * moveSpeed, rb.linearVelocity.y, runSpeed);
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

    private void OnCollisionEnter(Collision collision)
    {
        // Si le personnage touche un objet avec le tag "Obstacle"
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            GameOver();
        }
    }

    void GameOver()
    {
        // Recharge la scène pour simuler un écran de Game Over
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}