using System;using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;
using UnityEngine.Serialization;

public class NpcManager : MonoBehaviour  {
    
    
    public List<String> Npcs = new List<String>();
    private int NpcCount = 0;
    private float score = 0;
    private HighscoreManager highscoreManager;
    
    void Start() {
        for (int i = 0; i < 3; i++) Npcs.Add(null);
        highscoreManager = GameObject.Find("HighscoreManager").GetComponent<HighscoreManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Npcs[2] == null) AddRandomNpc();
    }

    public void GameOver()
    {
        Npcs.ForEach(npc =>
        {
            if(npc != null) Destroy(GameObject.Find(npc));
        });
        highscoreManager.addHighscore((int) score);
        Destroy(gameObject);
    }
    
    // create a new npc from prefab (with the name from NpcTypes.getRandNpcType()) to the scene 
    private void AddRandomNpc()
    {
        var npc = Instantiate(Resources.Load(NpcTypes.getRandNpcType())) as GameObject;
        npc.name = "npc-" + NpcCount;
        var height = npc.transform.localScale.y * GameManeger.sizeMultipicator;
        var width = npc.transform.localScale.x * GameManeger.sizeMultipicator;
        var depth = npc.transform.localScale.z * GameManeger.sizeMultipicator;
        npc.transform.localScale = new Vector3(width, height, depth);
        npc.transform.position = new Vector3(0, 0.1f, (0.3f + 1.8f) * GameManeger.sizeMultipicator);
        npc.transform.rotation = Quaternion.Euler(0, 180, 0);
        npc.GetComponent<Npc>().SetPosition(2);
        Npcs[2] = npc.name;
        NpcCount++;
    }
    
    public void NpcKilled(String npcName, float damage)
    {
        score += damage;
        highscoreManager.setCurrentScore((int)score);
        for (int i = 0; i < Npcs.Count; i++) 
            if(Npcs[i] == npcName) Npcs[i] = null;
    }
}

public static class NpcTypes
{ 
    public const string MiiFemale = "NpcFemale";
    public const string MiiMale = "NpcMale";

    public static String getRandNpcType()
    {
        string[] npcTypes = { MiiFemale, MiiMale };
        return npcTypes[UnityEngine.Random.Range(0, npcTypes.Length)];
    }
}