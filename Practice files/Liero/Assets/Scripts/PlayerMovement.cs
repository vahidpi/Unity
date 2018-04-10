using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public Camera cam;
    public Rigidbody2D rb2D;

    public GameObject ammo;
    public GameObject ammoSpawn;

    public GameObject testrayGround;
    public bool grounded;

    public CameraDraw cameraDraw;

    public GameObject testrayHead;
    public bool headHit;
    public bool firstHeadHit;

    public GameObject testrayFront;
    public GameObject testraySlope;
    public bool frontHit;
    public bool slopeHit;

    public float jumpForce;
    public float defaultGravity = 0.2f;

    public float movementSpeed;
    public float digingSpeed;
    public float redusedSpeed;

    public ParticleSystem diggingParticle;

    public GameObject hook;
    private GameObject hookInstance;


    // Use this for initialization
    void Start () {
        rb2D = GetComponent<Rigidbody2D>();
        cameraDraw = cam.GetComponent<CameraDraw>();

        ParticleSystem.EmissionModule em = diggingParticle.emission;
        em.enabled = false;
    }
	
	// Update is called once per frame
	void Update () {

        // write player to move left and right using A and D, make it jump using space
        // make player also turn left and right using loclascla.x
        // 1 hour


        grounded = cameraDraw.DrawRay(testrayGround.transform.position);
        headHit = cameraDraw.DrawRay(testrayHead.transform.position);
        frontHit = cameraDraw.DrawRay(testrayFront.transform.position);
        slopeHit = cameraDraw.DrawRay(testraySlope.transform.position);

        if (grounded==true)
        {
            rb2D.gravityScale = 0;
            rb2D.velocity = new Vector2(rb2D.velocity.x, 0);
        } else
        {
            rb2D.gravityScale = defaultGravity;
        }

        if (headHit)
        {
            rb2D.velocity = new Vector2(rb2D.velocity.x, 0);
        }

        if (Input.GetButtonDown("Jump"))
        {
            rb2D.velocity = Vector2.up * jumpForce;         
            rb2D.gravityScale = defaultGravity;
            grounded = false;
            
            
        }



        if(headHit && !firstHeadHit)
        {
            firstHeadHit = true;
            rb2D.velocity = new Vector2(rb2D.velocity.x, 0);
        }

        if (headHit == false && firstHeadHit == true)
        {
            firstHeadHit = false;
           
        }

        if (Input.GetAxisRaw("Horizontal") != 0)
        {
            if(!frontHit)
            {
                if(slopeHit)
                {
                    // we are from somting small obstcle
                    transform.Translate(Input.GetAxis("Horizontal") * redusedSpeed * Time.deltaTime, redusedSpeed * Time.deltaTime, 0);

                }
                else
                {
                    transform.Translate(Input.GetAxis("Horizontal") * movementSpeed * Time.deltaTime, 0, 0);
                    ParticleSystem.EmissionModule em = diggingParticle.emission;
                    em.enabled = false;
                }
            }
            else
            {
                transform.Translate(Input.GetAxis("Horizontal") * digingSpeed * Time.deltaTime, Input.GetAxis("Vertical") * digingSpeed * Time.deltaTime, 0);

                ParticleSystem.EmissionModule em = diggingParticle.emission;
                em.enabled = true;

                cameraDraw.Digging(transform.position,10);

            }

            transform.localScale=new Vector3(Input.GetAxisRaw("Horizontal") , 1, 1);
          
        }


        if (Input.GetButtonDown("Fire1"))
        {
            GameObject ammoInstanciate = Instantiate(ammo, ammoSpawn.transform.position, Quaternion.identity);
            ammoInstanciate.GetComponent<Rigidbody2D>().AddForce(transform.localScale.x * ammoSpawn.transform.right, ForceMode2D.Impulse);
        }

        if (Input.GetButtonDown("Fire2"))
        {
            if(!GetComponent<HingeJoint2D>())
            {
                hookInstance = Instantiate(hook, ammoSpawn.transform.position, Quaternion.identity);

                hookInstance.GetComponent<Rigidbody2D>().AddForce(transform.localScale.x * ammoSpawn.transform.right * 15, ForceMode2D.Impulse);
            }
            else
            {
                Destroy(hookInstance);
                Destroy(GetComponent<Rigidbody2D>());
            }
     
        }

        /*
         
         KotiTehtävä

        1.seperate player an player weapon and make user to able to aim(rotate the waepon) and
        shot in diferent direction

        2.make an additional weapon with diferent features(bigger raduis) and some button that changes between the weapone
        outlook of weapone can be samw
        prefab of the ammo should be red in the bigger weapon

        3.
        when player walks 0 is grounded, play really small dust particle effect behind the player
        (digs)

        Bonus
        4. make palyer able to dig to the ground straight left and right and up and down 45 degree. while gigging the  the envaronment is destroyd

        5.
        fix the bugs
         
         
         */


    }


}
