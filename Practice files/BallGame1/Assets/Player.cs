using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public float force;

    public GUIStyle myGUIStyle;

    public Rigidbody playerRB;

    // Use this for initialization
    void Start()
    {
        myGUIStyle.fontSize = 16;
        myGUIStyle.normal.textColor=Color.white;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            force += 5 * Time.deltaTime;
            GetComponent<MeshRenderer>().material.color = Color.red;
        }

        if(Input.GetMouseButtonUp(0))
        {
            GetComponent<MeshRenderer>().material.color = Color.yellow;
            Launch(force);
            force = 0;
        }
    }

    private void OnGUI()
    {
        GUI.Label(new Rect(10, 10, 100, 20), "Force: " + force);
    }

    void Launch(float forceAmount)
    {
        playerRB.AddForce(gameObject.transform.up * forceAmount, ForceMode.Impulse);
    }
}
