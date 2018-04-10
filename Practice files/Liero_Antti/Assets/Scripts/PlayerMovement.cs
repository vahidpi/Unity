using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public Camera cam;
    public Rigidbody2D rb2D;

    public GameObject testrayGround;
    public bool grounded;

    public GameObject testrayHead;
    public bool headHit;
    public bool firstHeadHit;

    public GameObject testrayFront;
    public bool frontHit;

    public GameObject testraySlope;
    public bool slopeHit; 

    public GameObject ammo;
    public GameObject ammoSpawn;

    public GameObject hook;
    private GameObject hookInstance; 

    public CameraDraw cameraDraw;

    public float jumpForce;
    public float movementSpeed;
    public float reducedSpeed; 

    public float diggingSpeed;
    public bool digging = false;

    public ParticleSystem diggingParticle; 

    public float defaultGravity; 

	// Use this for initialization
	void Start () {

        rb2D = GetComponent<Rigidbody2D>();
        cameraDraw = Camera.main.GetComponent<CameraDraw>();

        ParticleSystem.EmissionModule em = diggingParticle.emission;
        em.enabled = false;


    }
	
	// Update is called once per frame
	void Update () {

        grounded = cameraDraw.DrawRay(testrayGround.transform.position);
        headHit = cameraDraw.DrawRay(testrayHead.transform.position);
        frontHit = cameraDraw.DrawRay(testrayFront.transform.position);
        slopeHit = cameraDraw.DrawRay(testraySlope.transform.position);
        


        if (Input.GetAxisRaw("Horizontal") != 0)
        {
            if (frontHit == false)
            {
                if(slopeHit == true)
                {
                    // We are front of something small obstacle. Lets climb over it
                    transform.Translate(Input.GetAxis("Horizontal") * reducedSpeed * Time.deltaTime, 
                        reducedSpeed * Time.deltaTime, 0);
                }
                else
                {
                    transform.Translate(Input.GetAxis("Horizontal") * movementSpeed * Time.deltaTime, 0, 0);
                }
                ParticleSystem.EmissionModule em = diggingParticle.emission;
                em.enabled = false;
            }
            else
            {
                transform.Translate(Input.GetAxis("Horizontal") * diggingSpeed * Time.deltaTime, 
                    Input.GetAxis("Vertical") * diggingSpeed * Time.deltaTime, 0);

                ParticleSystem.EmissionModule em = diggingParticle.emission;
                em.enabled = true; 

                cameraDraw.Digging(transform.position, 10);
            }
            transform.localScale = new Vector3(Input.GetAxisRaw("Horizontal"), 1, 1);
        }

        if (Input.GetButtonDown("Fire1"))
        {
            GameObject ammoInstance = Instantiate(ammo, 
                ammoSpawn.transform.position, Quaternion.identity);

            ammoInstance.GetComponent<Rigidbody2D>().
                AddForce(transform.localScale.x * ammoSpawn.transform.right * 15, ForceMode2D.Impulse);

        }

        if (Input.GetButtonDown("Fire2"))
        {
            if (!GetComponent<SpringJoint2D>())
            {
                hookInstance = Instantiate(hook,
                    ammoSpawn.transform.position, Quaternion.identity);

                hookInstance.GetComponent<Rigidbody2D>().
                    AddForce(transform.localScale.x * ammoSpawn.transform.right * 15, 
                    ForceMode2D.Impulse);
            }
            else
            {
                Destroy(hookInstance);
                Destroy(GetComponent<SpringJoint2D>());

            }
        }




        if (Input.GetButtonDown("Jump") && grounded == true)
        {
            Debug.Log("Hypätään");
           
            rb2D.velocity = Vector2.up * jumpForce;
            rb2D.gravityScale = defaultGravity;
            grounded = false;
        }

        if(grounded == true)
        {
            rb2D.gravityScale = 0;
            rb2D.velocity = new Vector2(0, 0);
        }
        else
        {
            rb2D.gravityScale = defaultGravity;
        }

        if(headHit == true && firstHeadHit == false)
        {
            firstHeadHit = true; 
            rb2D.velocity = new Vector2(rb2D.velocity.x, 0);
        }

        if(firstHeadHit == true && headHit == false)
        {
            firstHeadHit = false; 
        }

        /*
        Homework

        1. Separate Player and PlayerWeapon and make the user to be able to aim (rotate)
        the weapon and shoot different directions

        2. Make an additional weapon with different features (bigger radius) and some button
        that changes between two weapons. Outlook of the weapon can be the same. Prefab
        of the ammo should be red in the "bigger" weapon. 

        3. When Player digs ground, play particle effect

        Bonus task:
        4. Make Player able to dig to the ground straight left and right 
        and up and down 45 degrees. While digging the environment is destroyed

        5. Fix all the bugs if any?

        */
	}
}
