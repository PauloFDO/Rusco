using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainPlayerGetHurt : MonoBehaviour {
    int MainPlayerHP = 4;

    public Transform DeadBG;
    public GameObject DamageBarAnimation;
    int totalDamage = 0;
    Rigidbody2D rigid;
    bool dead;

    public MainPlayerAnimations AnimationClass;

    public MainPlayerLiveBar liveBar;
    // Use this for initialization
    void Start () {
        //the cklass with the main player animations
        AnimationClass = GetComponent<MainPlayerAnimations>();

        var  DamageBar = GameObject.FindGameObjectsWithTag("LiveBar");

        //rigid body control
        rigid = GetComponent<Rigidbody2D>();

        DamageBarAnimation = DamageBar[0];
        liveBar = DamageBarAnimation.GetComponent("MainPlayerLiveBar") as MainPlayerLiveBar;

        
       // liveBar.Damage(totalDamage);
    }
	
	// Update is called once per frame
	void Update () {
		if(dead)
        {
            DeadBG.position = transform.position;
        }
	}

    void OnCollisionEnter2D(Collision2D coll)
    {

        if (coll.gameObject.tag == "InstaKill")
        {
            
            Die();
        }else if (coll.gameObject.tag == "Enemy")
        {
            totalDamage = totalDamage + 1;          

            liveBar.Damage(totalDamage);

            if (totalDamage == MainPlayerHP)
            {
                Die();               
            }

        }

    }

    void OnTriggerEnter2D(Collider2D coll)
    {

        if (coll.gameObject.tag == "InstaKill")
        {
         
            liveBar.Damage(MainPlayerHP);
    
            Die();
        }

        //here we recovery hp when take a piece of a hp object
        if (coll.gameObject.tag == "hp")
        {          
            if(totalDamage != 0)
            {
                totalDamage = totalDamage - 1;
            }
            

            liveBar.Damage(totalDamage);

            Destroy(coll.gameObject);
        }


    }


    private void Die()
    {       
        dead = true;
        Time.timeScale = 0.4F;
        AnimationClass.Die();
    }

}
