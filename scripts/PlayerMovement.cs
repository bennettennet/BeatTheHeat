using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


//WELCOME TO THE RESTAURANT
//TODAYS SPECIAL : SPAGHETTI

public class PlayerMovement : MonoBehaviour
{
    //speed of horizontal player movement
    public float speed;
    //jump force
    public float jForce;
    //gets the direction in order to use it to add a force to the player
    private float moveInput;

    private Rigidbody2D rb;

    //used to change the way the sprite faces
    private bool facingRight = true;

    private bool isGrounded;
    //These transforms are each under a point of the player so it knows when grounded even on an edge
    public Transform gCheck;
    public Transform gCheck2;
    public Transform gCheck3;
    public float checkR;
    public LayerMask whatIsGround;

    //variables for dash
    //speed of dash, says on the tin
    public float dashSpeed;
    //time spent in dash animation
    public float dashTime;
    //the timer used to measure how far through the dash
    private float dashCounter;
    //work around to get a timer down for the dash
    private bool dashCounterDown = false;

    //the amount the jumps are reduced when releasing "jump" ealry
    public float jumpSlow;
    
    //number of jumps available, will always be 2 by default
    private int extraJumps;
    //number of jumps the player has used, eg. 1 out of 2
    public int extraJumpsValue;

    //checks if the player is safe under a shadow
    public static bool shadowed = true;

    //checks if the player is dead
    public static bool dead = false;

    //check if the player is able input new movement commands
    public static bool stasis = false;

    //timer to give the player coyote time
    public float hangTime;
    //counts down from hangTime to 0
    private float hangCounter;

    //timer to give the player a tiny forgiveness for being in the sun
    public float sunTime;
    private float sunCounter;

    //count has a very specific purpose to make sure that when many shadows are together the player doesnt die
    //It checks for 2 onTriggersEnters in a row and then ignores the next OnTriggerExit
    private int count = 0;
    //used for checking if the lpayer is under multiple shadows then exiting one won't kill him
    public static bool canDie = false;




    void Start() 
    {
        //sets the initial jumps to full as the player always spawns on the ground
        extraJumps = extraJumpsValue;
        rb = GetComponent<Rigidbody2D>();
        dashCounter = dashTime;
        
    }

    private void FixedUpdate()
    {
        

        
        //checks the player is touching the ground
        if (Physics2D.OverlapCircle(gCheck.position, checkR, whatIsGround) == true || Physics2D.OverlapCircle(gCheck2.position, checkR, whatIsGround) == true || Physics2D.OverlapCircle(gCheck3.position, checkR, whatIsGround) == true)
        {
            isGrounded = true;
            //resets the hangCounter each time the player lands on a platform
            hangCounter = hangTime;
        }
        else
        {
            //allows for coyote time
            //starts the countdown of hangCounter
            hangCounter -= Time.deltaTime;
            //if the hangCounter falls below 0 the coyote time for the player is over
            if (hangCounter < 0)
            {
                isGrounded = false;
            }
            
        }
        //disables the plyaer from moving, used for game over and end of level
        if (stasis == false)
        {
            moveInput = Input.GetAxis("Horizontal");
            rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
        }
        
        
            
        //coordiante movement direction with player sprite
        if (facingRight == false && moveInput > 0)
        {
            Flip();
        }
        if (facingRight == true && moveInput < 0)
        {
            Flip();
        }
        

    }

    void Update()
    {

        //super cool dash which knows direction based on last key pressed
        //while the dash is still in motion
        if (dashCounter > 0)
        {
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                //using the function for sprite to tell the direction the player is facing in
                if (facingRight == true)
                {
                    //stops player from changing directions mid dash
                    stasis = true;
                    rb.velocity = Vector2.right * dashSpeed;
                    //starts the timer down, can't be called here as it is only a single frame
                    dashCounterDown = true;
                }
                if (facingRight == false)
                {
                    //stops player from changing directions mid dash
                    stasis = true;
                    rb.velocity = Vector2.left * dashSpeed;
                    //starts the timer down, can't be called here as it is only a single frame
                    dashCounterDown = true;
                }
            }

        }
        else
        {
            //allows player to move again
            stasis = false;
            //stops timer going down
            dashCounterDown = false;
            //stops the players velocity as it goes very fast in the dash
            rb.velocity = Vector2.zero;
            //resets dash timer
            dashCounter = dashTime;
        }
        //starts the timer down for dash
        if (dashCounterDown == true)
        {
            dashCounter -= Time.deltaTime;
            //stops the player moving vertically during the dash 
            rb.velocity = new Vector2(rb.velocity.x, 0);
        }


        

        

        //checks if the player is dead when there are no shadows and its umbrella shadow is not on
        if (canDie == true && Shadows.Ushadow == false)
        {
            //starts the countdown of time plyaer can remain in the sun without dying
            sunCounter -= Time.deltaTime;
            //this gives the player some leniency much like coyote time
            if (sunCounter < 0)
            {
                dead = true;
            }



        }
        else
        {
            sunCounter = sunTime;
        }
        
        //calls function when player is dead and restarts level
        if (dead == true)
        {
            PlayerSprite.PS.GetBurnt();
            GameManager.GM.GameOver();
            if (Input.GetKeyDown("space"))
            {
                Restart();
            }
            
        }
        //resets the timer on restart
        if (GameManager.playin == false)
        {
            if (Input.GetKeyDown("space"))
            {
                Time.timeScale = 0f;
                GameManager.playin = true;
                Restart();
            }
        }

        //resets jumps when touching ground
        if (isGrounded == true)
        {
            extraJumps = extraJumpsValue;
        }

        //makes the player jump if they have remaining jumps left
        if (Input.GetKeyDown("space") && extraJumps > 0)
        {
            rb.velocity = Vector2.up * jForce;
            extraJumps--;
        }
        //lets the player jump if they are touching the ground but have no jumps, however these should reset anyway
        else if (Input.GetKeyDown("space") && extraJumps == 0 && isGrounded == true)
        {
            rb.velocity = Vector2.up * jForce;
        }
        //this if lets the player control the height of their jump depending how long they hold space bar
        //if tehy hold space till the top of the jump this statement wont be called, how nifty
        if (Input.GetKeyUp("space") && rb.velocity.y > 0)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * jumpSlow);
        }

        //if the umbrella shadow is off and the mouse is clicked down the umbrella shadow will be enabled
        if (Input.GetMouseButtonDown(0) && Shadows.Ushadow == false)
        {
            Shadows.S.TurnOnUShadow();
        }
        //if the umbrella is on and the mouse button released the umbrella shadow will be disabled
        else if (Input.GetMouseButtonUp(0) && Shadows.Ushadow == true)
        {
            Shadows.S.TurnOffUShadow();
        }
        

    }

    




    //flips the player sprite
    void Flip()
    {
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        
        //if the plyaer touches the large object below the screen he respawns
        if (collision.gameObject.tag == "Respawn")
        {

            dead = true;

        }
        //if the plyaer touches the finish line it calls the finish command from gamemanager and stops the time
        else if (collision.gameObject.tag == "Finish")
        {
            Debug.Log("Finish");
            GameManager.GM.Finish();
            Time.timeScale = 0f;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        count++;
        //tells that the player is now under 2 shadows
        if (count == 2)
        {
            canDie = false;
        }else if(count == 1)
        {
            canDie = false;
        }


    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        //reduces the number of shadows the player is under
        count--;


        if (count == 0)
        {
            //if the player is not under any shadows he can now die
            canDie = true;
        }
        
        


    }

    //function called with each restart to reset all the variables, probably a better way of doing this
    public void Restart()
    {

        Time.timeScale = 1;
        dead = false;
        Shadows.Ushadow = false;
        count = 0;
        canDie = false;
        PlayerSprite.PS.GetNormal();
        stasis = false;
        //reloads the current level
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        
            
    }

}
