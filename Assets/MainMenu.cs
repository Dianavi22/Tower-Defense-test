using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string levelToLoad = "Level1";
  public void Play()
    {
        SceneManager.LoadScene(levelToLoad);
        GameManager.gameIsOver = false;
        PausedMenu.gameIsPaused = false;
    }

    public void Quit()
    {
        Application.Quit();
    }
}
