using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{
    public void GoBackToMainMenu() => SceneManager.LoadScene(0);

    public void ReloadGameScene() => SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    public void RestoreTimeScale() => Time.timeScale = 1;
}
