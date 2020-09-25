using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformUpDown : MonoBehaviour {

    public float speed = 0.1f;
    public float distance = 30;
    Vector3 movement;
    Vector3 movementDown;
    Vector3 initialPosition;
    bool up;

    // Use this for initialization
    void Start()
    {

        movement = new Vector3(transform.position.x, transform.position.y+distance);
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


        if (transform.position.y == movement.y)
        {
            up = false;
          
        }
        else if (transform.position.y < initialPosition.y)
        {
            up = true;

        }

        speed = speed;
        
        if (up)
        {

            transform.position = Vector3.MoveTowards(transform.position, movement, speed);
        }
        else
        {
          
            transform.position = Vector3.MoveTowards(transform.position, movementDown, speed);
        }
    }
}
