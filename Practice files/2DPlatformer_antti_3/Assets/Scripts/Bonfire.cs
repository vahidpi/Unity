using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bonfire : MonoBehaviour {

    public GameObject player;
    public float bonfireRadius; 

	// Use this for initialization
	void Start () {

        player = GameObject.Find("CharacterContainer");
	}

    // Update is called once per frame
    void FixedUpdate()
    {

        RaycastHit2D hit = Physics2D.Raycast(transform.position, player.transform.position);
        if (hit.distance < bonfireRadius)
        {
            Debug.Log("We are close enough!");
            // Let's increase player health. Do this. Time 10minutes.
            CharacterMovement playerInfo = player.GetComponent<CharacterMovement>();

            if (playerInfo.currentHealth < playerInfo.maxHealth)
            {
                player.GetComponent<CharacterMovement>().currentHealth += 0.1f;
            }


        }
        else
        {
            Debug.Log("We are too far away");

        }
    }
}
