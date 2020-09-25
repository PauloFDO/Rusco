using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformLeftRight : MonoBehaviour {

    public float speed = 0.1f;
    public float distance = 30;
    Vector3 movement;
    Vector3 movementLeft;
    Vector3 initialPosition;
    bool left;

    // Use this for initialization
    void Start () {

        movement = new Vector3(transform.position.x + distance, transform.position.y);
        movementLeft = new Vector3(transform.position.x - distance, transform.position.y);
        initialPosition = new Vector3(transform.position.x, transform.position.y);
    }
	
	// Update is called once per frame
	void Update () {
        Move();
	}


    public void Move()
    {


        if (transform.position.x == movement.x)
        {
            left = true;
        }
        else if(transform.position.x < initialPosition.x)
        {
            left = false;

        }

   

        if (!left) { 
           
            transform.position = Vector3.MoveTowards(transform.position, movement, speed);
        }
        else
        {
            
            transform.position = Vector3.MoveTowards(transform.position, movementLeft, speed);
        }
    }
}
