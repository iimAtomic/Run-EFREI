using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        // V�rifie si l'objet touch� a le tag "Obstacle"
        if (other.CompareTag("Obstacle"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    void Die()
    {
        Debug.Log("Le personnage est mort !");
        // Exemple : R�initialiser ou afficher un �cran de Game Over
        Destroy(gameObject); // D�truit le personnage
    }

}
