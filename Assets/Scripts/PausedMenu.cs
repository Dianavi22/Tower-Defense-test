using UnityEngine.SceneManagement;
using System.Collections.Generic;
using UnityEngine;

public class PausedMenu : MonoBehaviour
{
    public static bool gameIsPaused = false;
    public GameObject pauseMenuUI;
    public static PausedMenu instance;


    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Il y a plus d'une instance de PausedMenu dans la sc�ne");
            return;
        }

        instance = this;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {

            if (gameIsPaused)
            {
                Resume();
            }
            else
            {
                Paused();
            }
        }

    }

    void Paused()
    {
        BuildManager.instance.enabled = false;
        //Activer menu pause / l'afficher
        pauseMenuUI.SetActive(true);
        //arr�ter le temps
        Time.timeScale = 0;
        // changer le statut du jeu 
        gameIsPaused = true;
    }
    public void Resume()
    {
         BuildManager.instance.enabled = true;
        //D�sactiver menu pause / l'effacer
        pauseMenuUI.SetActive(false);
        //r�activer le temps
        Time.timeScale = 1;
        // changer le statut du jeu 
        gameIsPaused = false;
    }

 

}
