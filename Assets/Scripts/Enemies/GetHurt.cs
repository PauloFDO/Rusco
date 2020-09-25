using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetHurt : MonoBehaviour {

    public int hp = 3;
    bool groundMonster;
   
	// Use this for initialization
	void Start () {
        groundMonster = true;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "Basic Attack")
        {


            hp = hp - 1;


            if (hp == 0)
            {
                //attackPosition = new Vector3(player.position.x - 1, player.position.y, player.position.z);
                var deadPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z);

                var instance = (GameObject)Instantiate(Resources.Load("Fire"),
                deadPosition, Quaternion.identity) as GameObject;

                Destroy(gameObject);
            }


        } else if (collision.gameObject.tag == "Basic Attack Ice")
        {

            hp = hp - 1;


            if (hp == 0)
            {
                //attackPosition = new Vector3(player.position.x - 1, player.position.y, player.position.z);
                var deadPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z);


                if (groundMonster)
                {
                    var instance = (GameObject)Instantiate(Resources.Load("IceGround"),
                deadPosition, Quaternion.identity) as GameObject;
                }
                else
                {
                    var instance = (GameObject)Instantiate(Resources.Load("IceFlying"),
                deadPosition, Quaternion.identity) as GameObject;
                }



                Destroy(gameObject);
            }
        } }


        //trick to know if it is a flying monster or not
        private void OnCollisionStay2D(Collision2D collision)
        {
        if (gameObject.name.Contains("FlyingEnemy"))
        {
            groundMonster = false;
        }
        }


        }


