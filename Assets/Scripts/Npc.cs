using UnityEngine;

public class Npc : MonoBehaviour
{
    private int position = 0;
    private bool moving = false;
    private bool active = true;
    float destoryTime = 1.0f; // Time it waits before destroying the object after kill
    private NpcManager npcManager;
    
    // Start is called before the first frame update
    void Start()
    {
        npcManager = GameObject.Find("NpcManager").GetComponent<NpcManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!active)
        {
            destoryTime -= Time.deltaTime;
            if(destoryTime <= 0) Destroy(gameObject);
            return;
        }
        if (gameObject.transform.position.y < -10)
        {
            if(moving) npcManager.Npcs[position+1] = null;
            npcManager.Npcs[position] = null;
            Destroy(gameObject);
        }
        if (!moving && position > 0 && npcManager.Npcs[position - 1] == null) {
            npcManager.Npcs[position - 1] = gameObject.name;
            position--;
            moving = true;
        }
        if (moving) Move();
    }

    private void Move()
    {
        if (gameObject.transform.position.z < 0.3f + (position * 0.6f))
        {
            if (position == 1) gameObject.AddComponent(typeof(Rigidbody));
            moving = false;
            npcManager.Npcs[position + 1] = null;
        } else {
            var z = gameObject.transform.position.z;
            gameObject.transform.rotation = Quaternion.Euler(0, 180, 0);
            gameObject.transform.position = new Vector3(0, 0, z - 0.03f * GameManager.sizeMultipicator);
        }
    }

    public void HeadHitted(float damage)
    {
		if(!active) return;
        active = false;
        if(moving) npcManager.Npcs[position + 1] = null;
	    
	    // Play sound
	    GetComponent<AudioSource>().Play();
        npcManager.NpcKilled(gameObject.name, damage);
    }
    
    public int GetPosition()
    {
        return position;
    }
    
    public void SetPosition(int pos)
    {
        position = pos;
    }
}
