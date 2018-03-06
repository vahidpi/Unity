using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Obstacle : MonoBehaviour {

    public float damage;

    public int rotateSpeed;
	public int rotateDir;

	public int levelIndex;



	// Use this for initialization
	void Start () {

        rotateSpeed = Random.Range(1, 20);
		rotateDir = Random.Range(0,10);

		Scene scene = SceneManager.GetActiveScene();
		//Debug.Log("Active scene is '" + scene.name + "'.");
		levelIndex=scene.name[scene.name.Length-1]-48;


		switch (levelIndex) {
		case 0:
			rotateSpeed = 0;
			rotateDir = 0;
			break;
		case 1:
			rotateSpeed = Random.Range (1, 5);
			rotateDir = Random.Range (0, 10);
			break;
		case 2:
			rotateSpeed = Random.Range (10, 20);
			rotateDir = Random.Range (0, 10);
			break;
		default:
			rotateSpeed = 0;
			rotateDir = 0;
			break;
		}
    }
	
	// Update is called once per frame
	void Update () {

        //transform.Rotate(0,0, 2);

        
        //rdir = Random.Range(1, 2);
		if (rotateDir < 5)
            transform.Rotate(Vector3.back, 45 * Time.deltaTime * rotateSpeed);
        else
            transform.Rotate(Vector3.forward, 45 * Time.deltaTime * rotateSpeed);


        /*
         
         try to create obstacles that constatly rotate at some speed
         creage obstacle that rotate different speed 
         create a variable "rotatespeed"
         use transform.Rotate
         remember to use Time.deltaTime
         */


        /*
         sec hw

        create an empty gameobject and put 3 obstacles as child to the empty Gameobject
        put a scripts to empty game object that rotates se all 3 obstacles rotate too
         
         */


        /*
         thi hw

        create at least 3 diferent level of this game, difeernt difficulty, put the top of the object when 
        Debug.log(level passed)
         */
    }

    /*
    public float ReturnDamageValue()
    {
        return 0;
    }


    public void MakeMeGreen()
    {

    }
     */
}
