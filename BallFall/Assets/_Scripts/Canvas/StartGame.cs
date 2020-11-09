using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGame : MonoBehaviour
{
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Player.PlayerMain.gameObject.SetActive(true);
            LevelManager.IsStartGame = true;
            gameObject.SetActive(false);
        }
    }
}
