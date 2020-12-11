using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGame : MonoBehaviour
{
    [SerializeField]
    private GameObject _tutorial;
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (PlayerPrefs.GetInt("FirstEntry") == 0)
            {
                LevelManager.IsTutorial = true;
                _tutorial.SetActive(true);
                Time.fixedDeltaTime = 0;
                Time.timeScale = 0;
            }

            FacebookManager.Instance.LevelStart(PlayerPrefs.GetInt("Level"));

            Player.PlayerMain.gameObject.SetActive(true);
            LevelManager.IsStartGame = true;
            LevelManager.IsEntrance = true;

            gameObject.SetActive(false);
        }
    }
}
