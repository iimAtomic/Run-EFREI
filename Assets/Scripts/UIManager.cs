using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public GameObject panel;
    public GameObject playMenu;
    public GameObject gameOverMenu;

    public void PlayGame()
    {
        panel.SetActive(false); 
        playMenu.SetActive(false);
        Time.timeScale = 1f;
    }

    public void GameOver()
    {
        panel.SetActive(true); 
        gameOverMenu.SetActive(true);
        Time.timeScale = 0f;
    }

    public void ReplayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1f;
    }
    
}
