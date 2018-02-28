using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour {

    public float damage;

    public int rotatespeed;

	// Use this for initialization
	void Start () {

        rotatespeed = Random.Range(1, 20);


    }
	
	// Update is called once per frame
	void Update () {

        //transform.Rotate(0,0, 2);

        int rdir;
        rdir = Random.Range(1, 2);
        if (rdir == 1)
            transform.Rotate(Vector3.back, 45 * Time.deltaTime * rotatespeed);
        else
            transform.Rotate(Vector3.forward, 45 * Time.deltaTime * rotatespeed);


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
