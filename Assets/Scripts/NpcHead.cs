using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class NpcHead : MonoBehaviour
{

    private Npc npc;
    
    // Start is called before the first frame update
    void Start()
    {
        npc = transform.parent.GetComponent<Npc>();
    }

    // Update is called once per frame
    void Update() 
    {
        
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        if(transform.parent != null){
            if(collision.gameObject.name.ToLower().Contains("npc-") 
               || collision.gameObject.name.ToLower().Contains("head") ) return;
            
            gameObject.GetOrAddComponent<Rigidbody>().isKinematic = false;
            gameObject.GetOrAddComponent<UnityEngine.XR.Interaction.Toolkit.Interactables.XRGrabInteractable>();
            npc.HeadHitted(collision.relativeVelocity.magnitude);
        }
        
    }
    
}
