using UnityEngine;

public class GameManager : MonoBehaviour
{
    private bool gameEnded = false;
    void Update()
    {
        if (gameEnded)
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
        Debug.Log("Game Over !");
        return;
    }
}
