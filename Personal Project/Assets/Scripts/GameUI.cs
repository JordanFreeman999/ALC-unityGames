using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameUI : MonoBehaviour
{


    public GameObject endGameScreen;
    public TextMeshProUGUI endGameHeaderText;
    public TextMeshProUGUI endGameScoreText;

    public static GameUI instance;
    
    // Start is called before the first frame update
    void Awake()
    {
        instance = this;
    }


    // Update is called once per frame
    void Update()
    {
        
    }



    public void GetEndGameScreen(bool won, int score)
    {
        endGameScreen.SetActive(true);
        endGameHeaderText.text = won == true ? "You win" : "You Lose";
        endGameHeaderText.color = won == true ? Color.blue : Color.red;
        endGameScoreText.text = "<b>Score</b>\n" + score;
    }



}
