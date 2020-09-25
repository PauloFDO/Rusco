using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attackPlayerFromDistance : MonoBehaviour {

    public int speed = 3;
    float distance = 5;

    float attackStartPositiony = 0f;
    float attackStartPositionx = 0.5f;
    //Vector3 used to store the velocity of the enemy
    private Vector2 smoothVelocity = Vector3.zero;

    //we use this to know if player is at the left or right side
    public float dirNum;


    float attackSpeed = 1.5f;
    bool attackCD;

    //turn enemy to player stats
    GameObject[] target;
    Transform playerPos;
    Rigidbody2D rigid;

    // Use this for initialization
    void Start()
    {
        target = GameObject.FindGameObjectsWithTag("Player");
        rigid = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        playerPos = target[0].transform;
        //check if the player is at left or right to know where to attack      
        dirNum = LeftOrRight(playerPos);
        Attack(dirNum);
    }




    public void Attack(float leftOrRight)
    {
       

        if (!attackCD)
        {
            attackCD = true;
            var attackPosition = new Vector3(transform.position.x + leftOrRight, transform.position.y +attackStartPositiony, transform.position.z);
            var instance = (GameObject)Instantiate(Resources.Load("EnemyProyectile"),
            attackPosition, Quaternion.identity) as GameObject;

            StartCoroutine(AttackCooldown());
        }
       
    }

    IEnumerator AttackCooldown()
    {
        yield return new WaitForSeconds(3f);

        attackCD = false;
    }

    //know if the player is at left or right
    public float LeftOrRight(Transform Player)
    {
        var result = Player.position.x - transform.position.x;

        if (result > 0)
        {
            return attackStartPositionx;
        }
        else
        {
            return -attackStartPositionx;
        }

    }

   

}
