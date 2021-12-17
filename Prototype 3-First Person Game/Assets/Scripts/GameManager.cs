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


    void Update()
    {
        if(Input.GetButton("Cancel"))
        {
            TogglePauseGame();
        }
    }

    public void TogglePauseGame()
    {

        gamePaused = !gamePaused;
        Time.timeScale = gamePaused == true ? 0.0f : 1.0f;

        GameUI.instance.TogglePauseMenu(gamePaused);


        curScore.lockState = gamePaused == true ? curScoreLockMode.None : CursorLockMode.Locked;
    }

    public void AddScore(int score)
    {
        curScore += score;
        GameUI.instance.UpdateScoreText(curScore);
       
        if(curScore >= scoreToWin)
            WinGame();
    }

    public void WinGame()
    {
        GameUI.instance.SetEndGameScreen(true,curScore); 
    }

    public void LoseGame()
    {
        GameUI.instance.GetEndgameScreen(false, curScore);
        Time.timeScale = 0.0f;
        gamePaused = true;
    }
}
