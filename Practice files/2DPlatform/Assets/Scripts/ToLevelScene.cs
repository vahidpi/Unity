using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToLevelScene : MonoBehaviour {

    public string level;// which level want to go
    public GameObject spawnPoint;// where we want to go after level

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            // player near level object
            // add spawnpoint to gameStatus and Change scene

            GameStatus.storedSpawnPoint  = spawnPoint.name;
            Debug.Log("stored spwan" + GameStatus.storedSpawnPoint);
            SceneManager.LoadScene(level);
        }
            

        
    }
}
