using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonFire : MonoBehaviour {

    public GameObject player;
    public float bonfireRedius;

    // Use this for initialization
    void Start () {
        player = GameObject.Find("CharacterContainer");
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        RaycastHit2D hit = Physics2D.Raycast(transform.position,player.transform.position);
        if(hit.distance < bonfireRedius)
        {
            Debug.Log("We are close enough");
            CharacterMovement playerInfo = player.GetComponent<CharacterMovement>();
            

            if (playerInfo.currentHealth< playerInfo.maxHealth)
                player.GetComponent<CharacterMovement>().currentHealth += 0.1f;
        } else
        {
            Debug.Log("too away");
        }
	}
}
