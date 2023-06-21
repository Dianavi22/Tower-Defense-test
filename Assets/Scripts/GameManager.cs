using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject gameOverUI;

    public static bool gameIsOver = false;
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

  
}
