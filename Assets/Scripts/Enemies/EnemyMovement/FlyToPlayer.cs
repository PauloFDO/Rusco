using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyToPlayer : MonoBehaviour {

    public int speed = 1;
    //the distance between enemy and the player (a range enemy will have much more distance than a melee enemy)
    float minDistancex = 5;
    float distancey = -5;
    float AttackWhenPlayerGetCloserThan = 10f;
    //turn enemy to player stats
    GameObject[] target;
    Transform playerPos;
    Rigidbody2D rigid;
    SpriteRenderer sprite;
    // Use this for initialization
    void Start()
    {
        target = GameObject.FindGameObjectsWithTag("Player");
        rigid = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        playerPos = target[0].transform;
        var DistanceFromPlayer = transform.position.x - playerPos.transform.position.x;

        if (DistanceFromPlayer < AttackWhenPlayerGetCloserThan)
        {
            
            MoveToTouchPlayer();
            TurnEnemyToPlayer();
        }
    }


    public void MoveToTouchPlayer()
    {

        
            Vector2 velocity = new Vector2((transform.position.x - playerPos.transform.position.x + minDistancex) * speed,
            (transform.position.y - playerPos.transform.position.y + distancey) * speed);
            rigid.velocity = -velocity;
        
        




    }


    public void TurnEnemyToPlayer()
    {

        Vector3 heading = transform.position - playerPos.position;

        if (AngleDir(transform.forward, heading, transform.up) > 0)
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

    float AngleDir(Vector3 fwd, Vector3 targetDir, Vector3 up)
    {
        Vector3 perp = Vector3.Cross(fwd, targetDir);
        float dir = Vector3.Dot(perp, up);

        if (dir > 0f)
        {
            return -1f;
        }
        else if (dir < 0f)
        {
            return 1f;
        }
        else
        {
            return 0f;
        }
    }
}
