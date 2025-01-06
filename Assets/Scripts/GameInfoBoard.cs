using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameInfoBoard : MonoBehaviour
{
    
    private GameObject player;
    private HighscoreManager highscoreManager;
    private GameManeger game;
    private TextMeshPro textMeshPro;
    
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Main Camera");
        game = GameObject.Find("GameManager").GetComponent<GameManeger>();
        highscoreManager = GameObject.Find("HighscoreManager").GetComponent<HighscoreManager>();
        textMeshPro = GameObject.Find("GameInfoText").GetComponent<TextMeshPro>();
    }

    // Update is called once per frame
    void Update()
    {
        List<int> highscoreList = highscoreManager.getHighscoreList();
        
        textMeshPro.text = game.StatusInfo() 
                           + "\nScore: " + highscoreManager.getCurrentScore() 
                           + "\nHighscore: " + highscoreManager.getHighscore()
                           + "\nLeaderboard: ";
        
        for (int i = 0; i < Mathf.Min(3, highscoreList.Count); i++)
        {
            textMeshPro.text += "\n" + (i + 1) + ": " + highscoreList[i];
        }
    }
}
