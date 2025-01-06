using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreDisplay : MonoBehaviour
{
    // Start is called before the first frame update
    GameManager _game;
    void Start()
    {
        _game = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        int score = HighscoreManager.Instance.getCurrentScore();
        
        // Change the text of the score display (the script is attached to a Text object)
        GetComponent<TMPro.TextMeshProUGUI>().text 
            = _game.StatusInfo()
                        + "\nScore: " + score 
                        + "\nHighscore: " + HighscoreManager.Instance.getHighscore();
    }
}
