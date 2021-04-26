/*Character Movement Script 
 Brittany Blair */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Movement : MonoBehaviour
{
    public Animator anim;

    // Rigidbody
    private Rigidbody2D thisRB2D = null;
    public AudioSource LavaFootStep;
    public AudioSource StickyBlock;

    //Movement speed
    [SerializeField] float thisSpeed = 0.0f;

    //PossibleDirectionalMovement
    public Vector3 thisStop = Vector3.zero;
    public Vector3 thisRight = Vector3.right;
    public Vector3 thisLeft = Vector3.left;
    public Vector3 thisUP = Vector3.up;
    public Vector3 thisDown = Vector3.down;

    //Rotational Vectors
    public Vector3 thisRightRotation = Vector3.zero;
    public Vector3 thisLeftRotation = Vector3.zero;
    public Vector3 thisUPRotation = Vector3.zero;
    public Vector3 thisDownRotation = Vector3.zero;


    //CurrentDirectional Movement
    public Vector3 thisDirection = Vector3.zero;

    //Most recent Direction
    public Vector3 LastDirection = Vector3.zero;

    //last Position
    private Vector3 LastKnownPosition = Vector3.zero;

    //CurrentVelocity
    [SerializeField] private Vector3 CurrentVelocity = Vector3.zero;

    //bool will level restart
    public bool flameDeath = false;

    

    // Start is called before the first frame update
    void Start()
    {
        AudioSource[] audio = GetComponents<AudioSource>();
        LavaFootStep = audio[0];
        StickyBlock = audio[1];
        
        thisRB2D = GetComponent<Rigidbody2D>();
        thisDirection = thisStop;

        thisRightRotation.z = 0;
        thisLeftRotation.z = 180;
        thisUPRotation.z = 90;
        thisDownRotation.z = -90;
        LastKnownPosition = this.transform.position;

    }

    // Update is called once per frame
    void Update()
    {


        Vector3 Distance;

        Distance = this.transform.position - LastKnownPosition;

        print(Distance);

        if (!flameDeath)
        {



            // Check and see if the player is currently in motion or if they have stopped
            if (Distance.y <= .5 && Distance.y >= -.5 && Distance.x <= .5 && Distance.x >= -.5)
            {
                // if they have stopped, they can choose a new direction
                if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
                {
                    LastDirection = thisUP;
                    transform.localEulerAngles = thisUPRotation;
                    //LavaFootStep.Play();

                }
                else
                if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
                {
                    LastDirection = thisDown;
                    transform.localEulerAngles = thisDownRotation;
                    //LavaFootStep.Play();
                }
                else
                if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
                {
                    LastDirection = thisLeft;
                    transform.localEulerAngles = thisLeftRotation;
                    //LavaFootStep.Play();
                }
                else
                if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
                {
                    LastDirection = thisRight;
                    transform.localEulerAngles = thisRightRotation;
                    //LavaFootStep.Play();
                }

            }
        }

        thisDirection = LastDirection;

        //Calculate Velocity

        CurrentVelocity = thisSpeed * thisDirection;

        thisRB2D.velocity = CurrentVelocity;

        CurrentVelocity = thisRB2D.velocity;

        //characterAnimation
        if (CurrentVelocity != Vector3.zero)
        {
            print("walking");
            anim.SetBool("walking", true);
        }
        else
        {
            print("not walking");
            anim.SetBool("walking", false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject aOtherObject = collision.gameObject;

        Sticky aSticky;

        aSticky = aOtherObject.GetComponent<Sticky>();

        if (aSticky != null)
        {
            // if the player hits a sticky block they will stop and match the position of the Sticky block( short term center stop solution.)
            LastDirection = thisStop;
            this.transform.position = aSticky.transform.position;
            LastKnownPosition = this.transform.position;
            //StickyBlock.Play();
           
        }

        flamethrowerScript Flame;
        Flame = aOtherObject.GetComponent<flamethrowerScript>();

        if(Flame != null)
        {
            print("burnt");
            flameDeath = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject aOtherObject = collision.gameObject;

        Wall aWall;
        aWall = aOtherObject.GetComponent<Wall>();

        if(aWall != null)
        {
            // if a player hits a wall they will stop
            LastDirection = thisStop;
            LastKnownPosition = this.transform.position;
        }
    }
}
