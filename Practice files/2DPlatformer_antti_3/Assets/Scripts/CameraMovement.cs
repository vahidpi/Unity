using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {

    public Transform playerPosition;

    public float smoothTime;
    private Vector3 velocity = Vector3.zero;

    // Use this for initialization
    void Start () {

       // playerPosition = GameObject.FindGameObjectWithTag("Player").transform;
	}
	
	// Update is called once per frame
	void Update () {

        // Camera follows exactly same location than Player
        /*
        transform.position = new Vector3(playerPosition.position.x, 
            playerPosition.position.y+3.5f, transform.position.z);
        */
        // "Difficult Homework" 
        // Try to create a smooth movement for the camera. Where camera moves
        // Little bit after the ball and tries to reach to the ball all the time
        // If ball stops, then camera smoothly goes to the location of the player
        // Use Vector3.SmoothDamp
        /*
        Vector3 targetPosition = playerPosition.TransformPoint(
            new Vector3(playerPosition.position.x, playerPosition.position.y, -10));
*/

        Vector3 targetPosition = new Vector3(playerPosition.position.x, 
            playerPosition.position.y, -10);

        transform.position = Vector3.SmoothDamp(transform.position, 
            targetPosition, ref velocity, smoothTime);


    }
}
