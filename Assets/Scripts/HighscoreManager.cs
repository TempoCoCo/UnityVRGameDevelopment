using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighscoreManager : MonoBehaviour
{
    private int currentScore = 0;
    private List<int> highscoreList = new List<int>();
    
    public static HighscoreManager Instance { get; private set; }

    void Awake()
    {
        if (Instance != null) {
            Debug.LogError("There is more than one instance!");
            return;
        }

        Instance = this;
    }
    
    public int getCurrentScore()
    {
        return currentScore;
    }
    
    public void setCurrentScore(int score)
    {
        currentScore = score;
    }
    
    public List<int> getHighscoreList()
    {
        return highscoreList;
    }
    
    public void addHighscore(int score)
    {
        highscoreList.Add(score);
        highscoreList.Sort();
        highscoreList.Reverse();
    }

    public int getHighscore()
    {
        if (highscoreList.Count > 0)
        {
            return highscoreList[0];
        }
        
        return 0;
    }
}
