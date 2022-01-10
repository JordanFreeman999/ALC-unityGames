using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int scoreToWin;

    public int curScore;

    public bool gamePaused;

    public static GameManager instance;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        Time.timeScale = 1.0f;
    }



    public void AddScore(int score)
    {
        curScore += score;

       
        if(curScore >= scoreToWin)
            WinGame();
    }

    public void WinGame()
    {
        GameUI.instance.GetEndGameScreen(true, curScore); 
    }

    public void LoseGame()
    {
        GameUI.instance.GetEndGameScreen(false, curScore);
        Time.timeScale = 0.0f;
        gamePaused = true;
    }
}
