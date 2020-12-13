using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bottom : MonoBehaviour
{
    public void RestartBottom()
    {
        LevelManager.IsStartGame = false;
        LevelManager.IsGameWin= false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void MainMenuButton()
    {
        LevelManager.IsStartGame = false;
        LevelManager.IsGameWin = false;
        LevelManager.IsGameLose = false;

        FacebookManager.Instance.MainMenu();

        SceneManager.LoadScene(SceneManager.sceneCountInBuildSettings - 1);

    }
}
