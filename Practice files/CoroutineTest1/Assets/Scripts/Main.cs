using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour {

    public GameObject box;
    public GameObject ball;
    //public Transform targetPos;

    // Use this for initialization
    void Start () {
        

        for (int i=1;i<=10;i++)
        { 
            for (int j = 1; j <= 10; j++)
            {
                Vector3 pos = new Vector3(0, 0, 0);
                
                pos.x =i+ i*0.1f;
                pos.z = j+j * 0.1f;

                Instantiate(box, pos, Quaternion.identity);
            }
            
        }

        Instantiate(ball, new Vector3(0,0,0), Quaternion.identity);

        
    }


   

    // Update is called once per frame
    void Update () {
		
	}

   
}
