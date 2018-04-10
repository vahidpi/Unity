using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrapplingHook : MonoBehaviour
{

    public bool hit;
    public GameObject player;
    public Rigidbody2D rb2D;
    public CameraDraw cameraDraw;
    public SpringJoint2D hookConnection;

    // Use this for initialization
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        rb2D = GetComponent<Rigidbody2D>();
        cameraDraw = Camera.main.GetComponent<CameraDraw>();

    }

    // Update is called once per frame
    void Update()
    {

        hit = cameraDraw.DrawRay(transform.position);

        if (hit)
        {
            rb2D.velocity = Vector2.zero;
            rb2D.gravityScale = 0;

            if (!player.GetComponent<SpringJoint2D>())
            {
                hookConnection = player.AddComponent<SpringJoint2D>();

                // hookConnection.connectedBody = gameObject.GetComponent<Rigidbody2D>();
                hookConnection.connectedAnchor = transform.position;
                hookConnection.autoConfigureDistance = false;
            }
            // move player up and down
            hookConnection.distance += Input.GetAxis("Vertical") * 0.02f;
        }
        else
        {
            Destroy(player.GetComponent<SpringJoint2D>());

        }

    }
}
