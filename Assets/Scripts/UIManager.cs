using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public GameObject Panel;          // Background partagé
    public GameObject playMenu;       // Menu principal
    public GameObject gameOverMenu;   // Menu Game Over

    public static bool isGameRestarting = false; // Variable statique pour savoir si c'est un redémarrage

    void Start()
    {
        // S'assurer que le menu Game Over est caché
        gameOverMenu.SetActive(false);

        if (!isGameRestarting)
        {
            // Si ce n'est pas un redémarrage, affiche le menu principal
            Panel.SetActive(true);
            playMenu.SetActive(true);
            Time.timeScale = 0f; // Met le jeu en pause jusqu'à ce que le joueur appuie sur "Play"
        }
        else
        {
            // Si c'est un redémarrage, désactive le menu principal
            Panel.SetActive(false);
            playMenu.SetActive(false);
            Time.timeScale = 1f; // Le jeu démarre directement
            isGameRestarting = false; // Réinitialise l'état
        }
    }

    public void PlayGame()
    {
        Panel.SetActive(false);
        playMenu.SetActive(false); // Désactive le menu principal
        Time.timeScale = 1f;       // Reprend le jeu
    }

    public void GameOver()
    {
        Panel.SetActive(true);
        gameOverMenu.SetActive(true); // Affiche le menu Game Over
        Time.timeScale = 0f;          // Met le jeu en pause
    }

    public void ReplayGame()
    {
        Panel.SetActive(false);
        isGameRestarting = true; // Indique que le jeu est en cours de redémarrage
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Recharge la scène
    }
}
