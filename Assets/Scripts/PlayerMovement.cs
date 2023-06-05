using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;


public class PlayerMovement : MonoBehaviour
{

    // these aniamtions are to trun the laser container and trap trigger back tor ed as soon as the play gets hit
    // by the laser or the floor spikes

    [SerializeField] private Animator LaserTriggerOFFAnim;
    [SerializeField] private string LaserHMoveOFF = "LaserBeamTrigger OFF";
    [SerializeField] private Animator LaserMovementAnimOFF;
    [SerializeField] private string LaserFollowOFF = "Laser beam holder H movement";
    

    public HealthManager healthscript;//this is to access the HealthManager script
    Vector2 checkpointpos;// this is make avariable fro the transfrom position for my checkpoint
    
    public static float MovementSpeed = 6;// variable for how fast the player can move
    public static float JumpForce = 7; // How high the player can jump
    private float movement; // setting ym movement based on a float for controls
    bool FacingRight = true; // a bool variable for truning the character srpite left and right

    private Animator anim; // referencing the animator so i can use it later on
    private enum MovementState { idle, running, jumping, falling, } // creating a specil list that works
    // with an integer so 0 is idle, running is 1 and so forth so that way the animator can reference the script
    private MovementState state;// creating a variable name for movementState so that wya i can access the enum

    private Rigidbody2D rb; // setting up a component variable for rigidbody so that this script can access it

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();// creation a shortcut so that i don't have to type getcomponent eveytime
        checkpointpos = transform.position;// as soon as the game startsassign checkpointpos to the current trnasform position
        anim = GetComponent<Animator>();// as soon as the dame starts it will access the animator componnet
    }
    // this is to reference the player movement for the new input system
    public void Move(InputAction.CallbackContext context)
    {
        movement = context.ReadValue<Vector2>().x;
    }
    // thi is the reference the jump button to the new input system
    public void Jump(InputAction.CallbackContext context)
    {
        if(context.performed && Mathf.Abs(rb.velocity.y) < 0.001f)
        {
            rb.AddForce(new Vector2(0, JumpForce), ForceMode2D.Impulse);
        }
    }

    public void ExitGame(InputAction.CallbackContext context)
    {
        if(context.performed && PauseManager.paused == true)
        {
            Application.Quit();
            Debug.Log("You Have exited the game");
        }


    }

    private void FixedUpdate()
    {
           movement = Input.GetAxisRaw("Horizontal"); // setting my movement float variable to keyboard controls to left and right with arrow keys, A and D keys
        rb.velocity = new Vector2 (movement * MovementSpeed,rb.velocity.y); // positioning the controls so that they run along the x axis only
                                                                                             // Then multiplying it by the movementspeed so that adds motion to the movement itself

        // if the plauer is moving left or right then activate the movementstate and set it to running
        if (movement > 0.01f)
        {
            state = MovementState.running;
            
        }

        else if (movement < -0.01f)
        {
            state = MovementState.running;
            
        }

        else
        {
            state = MovementState.idle;
        }

    }

    // Update is called once per frame
    void Update()
    {
       
        

         if (Input.GetButtonDown("Jump") && Mathf.Abs(rb.velocity.y) < 0.001f) //setting up the jump controls to the spacebar
            //then making sure the player only jumps once by using the math function absolute so that if the jump height is over 0.001 then you can't jump again until you hit the ground
        {
            rb.AddForce(new Vector2 (0, JumpForce), ForceMode2D.Impulse); // adding the jumpForce so that it runs only through the Y axis

        }
        {
            if (movement < -0.01f && FacingRight) // if the player movements X axis is less than zero and facing right is true then the player will keep facing right
            {
                
                betterFlip();
            }

            else if (movement > 0.0f && !FacingRight) // if the player movements X axis is more than zero and facing right is not true then the player will keep facing left
            {

                
                betterFlip();
            }
            


        }

        // when the player jumps then activate the jumping movement state
        if (rb.velocity.y > .1f)

        {
            state = MovementState.jumping;
        }


        // when the player has stopped jumping activate the falling movementState
        else if (rb.velocity.y < -.1f)
        {
            state = MovementState.falling;
        }
        anim.SetInteger("state", (int)state);// this is to make sure that the enum is set asa integer so that is can be
        // accessed by the animator componet back in the editor screen


        void betterFlip() // this is used to flip the sprite by 180 degrees on the Y axis and I used transform.Rotate so that the player can also fire left and right
        {
            FacingRight = !FacingRight;
            transform.Rotate(0f, 180f, 0f);
        }

    }


    private void OnTriggerEnter2D(Collider2D collision)
        // this is so that the security light can do damage to the player
        // and reset there postion based on the last check point
    {
        if(collision.gameObject.CompareTag("Security"))
        {
            healthscript.TakeDamage(20);

            die();
        }

        // if I'm hit by the floor spikes then I respawn but the laser
        // that follows the player will also reset based on the LaserMoveH script
        // I also set the TrapON back to false to help activate something in the LaserMoveH script
        // later on as well
        if (collision.gameObject.CompareTag("Spikes"))
        {
            healthscript.TakeDamage(40);

            die();

            LaserTriggerOFFAnim.Play(LaserHMoveOFF, 0, 0.0f);
            LaserMovementAnimOFF.Play(LaserFollowOFF, 0, 0.0f);

            LaserTrigger.TrapOn = false;
            HideSprite.SpriteHidden = true;

        }

        // the secuirty beam tag is fro the moving laser that way 
        // I won't get confused with the rotating laser but I will
        // take damage and this will also activate the animations
        // to go back to red
        if (collision.gameObject.CompareTag("Security Beam"))
        {
            LaserTriggerOFFAnim.Play(LaserHMoveOFF, 0, 0.0f);
            LaserMovementAnimOFF.Play(LaserFollowOFF,0, 0.0f);

            healthscript.TakeDamage(20);

            die();

            HideSprite.SpriteHidden = true;

            LaserTrigger.TrapOn = false;

        }

        if (collision.gameObject.CompareTag("BuzzBlade"))

        {
            healthscript.TakeDamage(40);

            die();

        }
        if(collision.gameObject.CompareTag("Green Laser")||collision.gameObject.CompareTag("Blue Laser"))
        {
            healthscript.TakeDamage(20);

            die();

            HideSprite.SpriteHidden = true;

            LaserTrigger.TrapOn = false;

        }

        if(collision.gameObject.CompareTag("Restore"))
        {
            healthscript.Heal(20);
        }

    }

    
    void die()
        // a private void to put the respawn method in
    {
        respawn();
    }

    void respawn()
        // a private void to assign the transform.position to checkpointpos so that way it knows where to put the player
        // when they die
    {
        transform.position = checkpointpos;
    }

    public void updatecheckpoint(Vector2 pos)
        // this public method is to update checkpoint eveyr time the player colliders with a new one
    {
        checkpointpos = pos;
    }
}
