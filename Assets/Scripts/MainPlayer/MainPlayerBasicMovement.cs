using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainPlayerBasicMovement : MonoBehaviour {

    private Vector2 directionalInput;

    //force of the character jump
    float jumpForce = 16f;

    //the character only can jump after touch the floor
    bool isGrounded = true;
    //right and left speed
    float movementSpeed = 10;

    //foot (it have to be under our character)
    BoxCollider2D footCollider;
    float footHigh = 0.004f;
    float footWidth = 0.2f;
    float footPosition = -0.05f;
    private Vector3 velocity;

    //freeze the player for a short period of time
    bool paralysis;


    SpriteRenderer sprite;
    Rigidbody2D rigid;


    public MainPlayerAnimations AnimationClass;

    //buttons movement

    bool right;
    bool left;
   //the up movement is in basic attack as it doesnt produce any movement at all



    // Use this for initialization
    void Start()
    {      
        //rigid body control
        rigid = GetComponent<Rigidbody2D>();
        //we use this to flip the sprite
        sprite = GetComponent<SpriteRenderer>();
        //the cklass with the main player animations
        AnimationClass = GetComponent<MainPlayerAnimations>();
     

        //we crate a box collider for the foot,  it will allow us know when the player is touching the floor
        footCollider = this.gameObject.AddComponent<BoxCollider2D>();
        footCollider.offset = new Vector3(0, footPosition, 0);
        footCollider.size = new Vector3(footWidth, footHigh, 0);
        footCollider.isTrigger = true;
    }

    void FixedUpdate()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        

            if (Input.GetKey(KeyCode.A))
            {
                AWSDMovement("a");
            }

            if (Input.GetKey(KeyCode.D))
            {
                AWSDMovement("d");
            }





            //jump

            if (Input.GetKey(KeyCode.Space))
            {
                Jump();
            }

        
     

            //buttons
            if (right)
            {
                AWSDMovement("d");
            }

            if (left)
            {
                AWSDMovement("a");
            }




            if (!Input.anyKey && !left && !right)
            {

                AWSDMovement("stop");
            }
        
    }


    public void SetDirectionalInput(Vector2 input)
    {
        directionalInput = input;
    }


    //move pressing buttons

        public void Left()
    {
        left = !left;
    }

    public void Right()
    {
        right = !right;
    }

    


    public void JumpButton()
    {
        Jump();
    }



    //control what happens when you press awsd
    public void AWSDMovement(string action)
    {

        if (!paralysis)
        {

            //go left
            if (action == "a")
            {
                //we cannot run in the air!
                AnimationClass.Run();

                transform.position += -transform.right * Time.deltaTime * movementSpeed;
                sprite.flipX = true;
            }

            // go right
            if (action == "d")
            {
                AnimationClass.Run();

                transform.position += transform.right * Time.deltaTime * movementSpeed;
                sprite.flipX = false;

            }

            // go right
            if (action == "stop")
            {
                AnimationClass.StopRun();
            }
        }


    }

   

  

    //behaviour when we press space bar
    public void Jump()
    {     

        if (isGrounded)
        {          
            //we first make sure to set velocity to 0, sometimes if you hit a border while jumping it may jump again multiplaying the force and jumping really high    
            rigid.AddForce(new Vector2(0,jumpForce), ForceMode2D.Impulse);

            if(rigid.velocity.y > jumpForce)
            {
                velocity.y = jumpForce;

                rigid.velocity = velocity;
            }

            AnimationClass.jump();
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "FlyingoFloor")
        {

            isGrounded = true;
        }
      
        //if the main character touch "flying floor" he can jump forever, it will aloow him to reach the final boss
        if (isGrounded == false && collision.gameObject.tag != "FlyingoFloor")
        {
            //the foot touched the ground, we can jump again
            isGrounded = true;
            //stop jump animation started on jump button
            AnimationClass.EndJump();                     
        }

        

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag != "FlyingoFloor")
        {
            //the foot left the ground, no more jumps
            AnimationClass.EndJumpTriggerReset();
            isGrounded = false;

        }
    }

   

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Enemy")
        {
            if (sprite.flipX)
            {
                rigid.AddForce(new Vector2(10, 0), ForceMode2D.Impulse);

               
            }
            else
            {
                rigid.AddForce(new Vector2(-10, 0), ForceMode2D.Impulse);
            }

            StartCoroutine(Paralysis());

        }

        //if we are on a plataform we need to move with it

        if (coll.gameObject.tag == "Platform")
        {
            transform.parent = coll.transform;
        }
        
    }


    void OnCollisionExit2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Platform")
        {
            transform.parent = null;

        }
    }

    //after be hit by an enemy we cannot move for a short period of time
    IEnumerator Paralysis()
    {
        paralysis = true;
        yield return new WaitForSeconds(0.5f);
        paralysis = false;
    }

}
