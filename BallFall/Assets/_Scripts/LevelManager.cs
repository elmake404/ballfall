using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static bool IsGameWin,IsGameLose, IsStartGame,IsEntrance, IsTutorial;
    public static int Namberbonus,NamberActivationBonus;

    void Start()
    {
        IsGameLose = false;
        IsGameWin = false;
        //IsStartGame = true;
    }
    void Update()
    {
        
    }
}
