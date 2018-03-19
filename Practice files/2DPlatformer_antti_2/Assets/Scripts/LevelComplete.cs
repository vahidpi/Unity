using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelComplete : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Player has hit the particle effect -> to WorldMap
        if (collision.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene("WorldMap");

        }
    }

}
