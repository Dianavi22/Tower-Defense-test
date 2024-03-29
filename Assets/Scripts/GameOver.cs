using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{

    public SceneFader sceneFader;


    [SerializeField] Text roundsText;
    private void OnEnable()
    {
        roundsText.text = PlayerStats.rounds.ToString();
    }

    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        GameManager.gameIsOver = false;
    }
    public void Menu()
    {
        sceneFader.FadeTo("MainMenuScene");

    }
    public void Quit()
    {
        Application.Quit();
    }
}
