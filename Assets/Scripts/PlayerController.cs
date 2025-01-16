using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        // Vérifie si l'objet touché a le tag "Obstacle"
        if (other.CompareTag("Obstacle"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    void Die()
    {
        Debug.Log("Le personnage est mort !");
        // Exemple : Réinitialiser ou afficher un écran de Game Over
        Destroy(gameObject); // Détruit le personnage
    }

}
