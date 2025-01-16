using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        // Si le personnage touche un objet avec le tag "Obstacle"
        if (other.gameObject.CompareTag("Obstacle"))
        {
            GameOver();
        }
    }

    void GameOver()
    {
        // Recharge la sc�ne pour simuler un �cran de Game Over
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
