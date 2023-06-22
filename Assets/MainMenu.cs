using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string levelToLoad = "Level1";
    public SceneFader sceneFader;
  public void Play()
    {
        sceneFader.FadeTo(levelToLoad);
        GameManager.gameIsOver = false;
        PausedMenu.gameIsPaused = false;
    }

    public void Quit()
    {
        Application.Quit();
    }
}
