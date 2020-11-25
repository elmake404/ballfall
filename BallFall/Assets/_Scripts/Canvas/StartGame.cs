using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGame : MonoBehaviour
{
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            FacebookManager.Instance.LevelStart(PlayerPrefs.GetInt("Level"));
            Player.PlayerMain.gameObject.SetActive(true);
            LevelManager.IsStartGame = true;
            LevelManager.IsEntrance = true;
            
            gameObject.SetActive(false);
        }
    }
}
