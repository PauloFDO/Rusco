using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTrap : MonoBehaviour {
    public float speed = 0.05f;
    public float distance = 2;
    Vector3 movement;
    Vector3 movementDown;
    Vector3 initialPosition;
    bool up;

    // Use this for initialization
    void Start()
    {

        movement = new Vector3(transform.position.x, transform.position.y);
        movementDown = new Vector3(transform.position.x, transform.position.y - distance);
        initialPosition = new Vector3(transform.position.x, transform.position.y);
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }


    public void Move()
    {


        if (transform.position.y == initialPosition.y)
        {
            up = true;

        }
        else if (transform.position.y == movementDown.y)
        {
            up = false;

        }

 
        if (up)
        {
            
            transform.position = Vector3.MoveTowards(transform.position, movementDown, speed);
            
        }
        else
        {
           
            transform.position = Vector3.MoveTowards(transform.position, movement, speed);
        }
    }


}
