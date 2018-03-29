using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 

public class Box : MonoBehaviour {
    public Renderer rend;
    public Material activeMat;
    public Material nonActiveMat;
    

    // Use this for initialization
    void Start () {
        rend = GetComponent<Renderer>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnMouseEnter()
    {
        rend.material= activeMat;      
    }
   
    void OnMouseExit()
    {
        rend.material = nonActiveMat;
    }

    private void OnMouseDown()
    {

        // GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().target = transform;
       
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().counter = 0;
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().StartMoving(transform);
        
    }
}
