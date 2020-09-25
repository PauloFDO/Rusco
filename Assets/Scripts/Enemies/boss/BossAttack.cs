using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttack : MonoBehaviour {

    public float speedUp = 0.1f;
    public float speedDown = 0.3f;
    public float distance = 1;
    Vector3 movement;
    Vector3 movementDown;
    Vector3 movementAdjust;
    Vector3 initialPosition;
    bool up = true;



    public float speedSides = 0.1f;
    public float distanceSides = 30;
    Vector3 movementSides;
    Vector3 movementLeftSides;
    Vector3 initialPositionSides;
    bool leftSides;

    //the boss cannot attack between animations
    bool AllowAttack;


    bool moveSides=false;

    // Use this for initialization
    void Start()
    {

     
    }

    void SetInitialPosition()
    {
        movement = new Vector3(transform.position.x, transform.position.y + distance);
        movementAdjust = new Vector3(transform.position.x, transform.position.y + distance - 0.2f);
        movementDown = new Vector3(transform.position.x, transform.position.y - distance);
        initialPosition = new Vector3(transform.position.x, transform.position.y);



        movementSides = new Vector3(transform.position.x + distance, transform.position.y + distance);
        movementLeftSides = new Vector3(transform.position.x - distance, transform.position.y + distance);
        initialPositionSides = new Vector3(transform.position.x, transform.position.y + distance);
    }

    // Update is called once per frame
    void Update()
    {
                 
        
    }

    void FixedUpdate()
    {

        if (AllowAttack)
        {
            if (!moveSides)
            {

                Move();
            }
            else
            {
                MoveSides();
            }
        }
    }


    public void Move()
    {

     
        if (transform.position.y == movement.y)
        {
            Debug.Log(" satrt coro in move");
            StartCoroutine(MoveSidesEnable());         
        }
        else if (transform.position.y < initialPosition.y)
        {
            up = true;
        }


        if (up)
        {

            transform.position = Vector3.MoveTowards(transform.position, movement, speedUp);
        }
        else if(!moveSides)
        {
            DownPosition();
            transform.position = Vector3.MoveTowards(transform.position, movementDown, speedDown);
        }
    }



    void DownPosition()
    {
        if(!moveSides && !up)
        {
           
            movementDown = new Vector3(this.transform.position.x, transform.position.y - distance);
        }
    }

    IEnumerator MoveSidesEnable()
    {

        Debug.Log("Start coro");
        moveSides = true;
        yield return new WaitForSeconds(2f);
        movementAdjust = new Vector3(transform.position.x, transform.position.y + - 0.01f);
        movement = new Vector3(transform.position.x, transform.position.y);
        movementDown = new Vector3(transform.position.x, transform.position.y - distance);
        transform.position = movementAdjust;
        moveSides = false;
        up = false;      
    }


    public void MoveSides()
    {
        if (up)
        {

            if (transform.position.x == movementSides.x)
            {
              
                leftSides = true;
            }
            else if (transform.position.x < initialPositionSides.x)
            {
            
                leftSides = false;

            }



            if (!leftSides)
            {

                transform.position = Vector3.MoveTowards(transform.position, movementSides, speedSides);
            }
            else
            {
             
                transform.position = Vector3.MoveTowards(transform.position, movementLeftSides, speedSides);
            }
        }
    }

    public void EnableDisableAttacks()
    {
        SetInitialPosition();
        AllowAttack = !AllowAttack;
    }
}