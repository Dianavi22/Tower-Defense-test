using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject gameOverUI;
    public string nextLevel = "Level2";
    public static bool gameIsOver = false;
    public int levelToUnlock = 2;
    public SceneFader sceneFader;
    void Update()
    {
        if (Input.GetKeyDown("l"))
        {
            EndGame();
            print("Game Over");
        }

        if (gameIsOver)
        {
            return;
        }

        if(PlayerStats.lives <= 0)
        {
            EndGame();
        }
    }

    private void EndGame()
    {
        gameIsOver = true;
        gameOverUI.SetActive(true);
        return;
    }

    public void WinLevel()
    {

        if(levelToUnlock > PlayerPrefs.GetInt("levelReached", 1))
        {
            PlayerPrefs.SetInt("levelReached", levelToUnlock);
        }
        sceneFader.FadeTo(nextLevel);

    }

}
