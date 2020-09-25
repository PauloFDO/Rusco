using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkToPlayer : MonoBehaviour {

    public int speed = 30;
    float distance = 0; 
    //Vector3 used to store the velocity of the enemy
    private Vector2 smoothVelocity = Vector3.zero;
    //the distance between enemy and the player (a range enemy will have much more distance than a melee enemy)
    float minDistance = 0;
    float AttackWhenPlayerGetCloserThan = 20f;
    SpriteRenderer sprite;



    //turn enemy to player stats
    GameObject[] target;
    Transform playerPos;
    Rigidbody2D rigid;
   

    // Use this for initialization
    void Start()
    {
        //we use this to flip the sprite
        sprite = GetComponent<SpriteRenderer>();
        target = GameObject.FindGameObjectsWithTag("Player");
        rigid = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        //we can have problems when the player die, so we catch the error


        try
        {
            
                playerPos = target[0].transform;
                MoveToTouchPlayer();
                TurnEnemyToPlayer();
            
        }
        catch { }

        

        
    }


    public void MoveToTouchPlayer()
    {

        var DistanceFromPlayer = transform.position.x - playerPos.transform.position.x;

        if (DistanceFromPlayer < AttackWhenPlayerGetCloserThan)
        {
            //minimun distance between the player and the enemy (the enemy will not try get closer than this)
            if (Vector3.Distance(transform.position, playerPos.position) > minDistance)
            {

                float step = speed * Time.deltaTime;
                transform.position = Vector3.MoveTowards(transform.position, playerPos.transform.position, step);

                //var velocity = new Vector2((transform.position.x - playerPos.transform.position.x) * speed, 1);
                //rigid.velocity = -velocity;
            }
        }
    }
    
    public void TurnEnemyToPlayer()
    {
        
        Vector3 heading = playerPos.position - transform.position;

        if (AngleDir(transform.forward,heading, transform.up) >0)
        {
            sprite.flipX = true;
        }
        else
        {
            sprite.flipX = false;
        }
        
        //Vector3 dir = transform.position - playerPos.position;
        //float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        //transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

    }


    //know if an enemy is at the left side or right side

    float AngleDir(Vector3 fwd, Vector3 targetDir, Vector3 up)
    {
        Vector3 perp = Vector3.Cross(fwd, targetDir);
        float dir = Vector3.Dot(perp, up);

        if (dir > 0f)
        {
            return 1f;
        }
        else if (dir < 0f)
        {
            return -1f;
        }
        else
        {
            return 0f;
        }
    }

}
