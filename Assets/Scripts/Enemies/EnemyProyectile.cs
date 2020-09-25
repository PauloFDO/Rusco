using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProyectile : MonoBehaviour {

    public int speed = 1;
    GameObject[] target;
    Transform playerPos;
    Rigidbody2D rigid;

    // Use this for initialization
    void Start () {
        target = GameObject.FindGameObjectsWithTag("Player");
        rigid = GetComponent<Rigidbody2D>();
        playerPos = target[0].transform;
        Vector2 velocity = new Vector2((transform.position.x - playerPos.transform.position.x) * speed, (transform.position.y - playerPos.transform.position.y) * speed);
        GetComponent<Rigidbody2D>().velocity = -velocity;

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnCollisionEnter2D(Collision2D collision)
    {

        if(collision.gameObject.tag !="Enemy"){
            Destroy(gameObject);
        }
        
    }
}
