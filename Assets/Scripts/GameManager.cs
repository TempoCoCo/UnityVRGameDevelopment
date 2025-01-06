using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static float sizeMultipicator = 1;
    private float pauseTime = 10;
    private float gameTime = 60;
    private bool gameStarted = false;
    private int round = 1;
    
    // Start is called before the first frame update
    void Start()
    {
        sizeMultipicator = GameObject.Find("House").transform.localScale.x * 10;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameStarted)
        {
            gameTime -= Time.deltaTime;
            if (gameTime < 0)
            {
                round++;
                gameTime = 60;
                gameStarted = false;
                GameObject.Find("NpcManager").GetComponent<NpcManager>().GameOver();
            }
        }
        else
        {
            pauseTime -= Time.deltaTime;
            if (pauseTime < 0)
            {
                pauseTime = 10;
                gameStarted = true;
                var npcMAneger = Instantiate(Resources.Load("NpcManeger"));
                npcMAneger.name = "NpcManager";
            }
        }
    }

    public String StatusInfo()
    {
        if(gameStarted) return "Round: " + round + "\nTime: " + (int) gameTime + "/60";
        return "Pause" + "\nTime: " + (int) pauseTime + "/10";
    }
    
}
