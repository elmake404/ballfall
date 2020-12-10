using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameContinue : MonoBehaviour
{
    [SerializeField]
    private GameObject _bottom;
    private void Start()
    {
        _bottom.SetActive(false);
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && _bottom.activeSelf)
        {
            LevelManager.IsGameWin = false;
            if (PlayerPrefs.GetInt("Scenes") < SceneManager.sceneCountInBuildSettings)
            {
                SceneManager.LoadScene(PlayerPrefs.GetInt("Scenes"));
            }
            else
            {
                PlayerPrefs.SetInt("Scenes", 1);
                SceneManager.LoadScene(PlayerPrefs.GetInt("Scenes"));
            }
        }
    }
    private void FixedUpdate()
    {
        if (LevelManager.NamberActivationBonus <= 0 && LevelManager.IsGameWin)
        {
            _bottom.SetActive(true);
        }
    }
}
