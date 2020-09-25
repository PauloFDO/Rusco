using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicAttack : MonoBehaviour {

    public MainPlayerAnimations AnimationClass;
    
    float attackSpeed = 15f;
    Rigidbody2D rigid;
    Vector3 attackPosition;
    Transform player;
    SpriteRenderer sprite;
    //we change the live bar from ice to fire
    public MainPlayerLiveBar liveBar;
    public GameObject DamageBarAnimation;
    bool ice;


    //when player press up he shoot up
    bool up;

    // Use this for initialization
    void Start()
    {
        //we use this to flip the sprite
        sprite = GetComponent<SpriteRenderer>();
        //the cklass with the main player animations
        AnimationClass = GetComponent<MainPlayerAnimations>();

        

        //rigid body control
        rigid = GetComponent<Rigidbody2D>();

        var DamageBar = GameObject.FindGameObjectsWithTag("LiveBar");
        DamageBarAnimation = DamageBar[0];
        liveBar = DamageBarAnimation.GetComponent("MainPlayerLiveBar") as MainPlayerLiveBar;
       


        player = GetComponent<Transform>();
     
    }

    // Update is called once per frame
    void Update()
    {
        if (Application.platform != RuntimePlatform.Android)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Attack();
            }
        }
        
    }

    public void ButtonAttack()
    {
        Attack();
    }

    public void AttackLeft()
    {
        //attackPosition = new Vector3(player.position.x - 1, player.position.y, player.position.z);
        attackPosition = new Vector3(player.position.x - 1f, player.position.y + 0.3f, player.position.z);

        var instance = new GameObject();

        

        if (ice)
        {
            instance = (GameObject)Instantiate(Resources.Load("basic attack ice"),
            attackPosition, Quaternion.identity) as GameObject;
        }
        else
        {
            
            instance = (GameObject)Instantiate(Resources.Load("basic attack"),
                             attackPosition, Quaternion.identity) as GameObject;
        }



        var instanceRigid = instance.GetComponent<Rigidbody2D>();
        instanceRigid.AddForce(new Vector2(-attackSpeed, 0), ForceMode2D.Impulse);


        var script = instance.GetComponent<BasicAttackScript>();
        script.AttackLeft();
    }


    public void AttackRight()
    {
        attackPosition = new Vector3(player.position.x + 1f, player.position.y + 0.3f, player.position.z);

        var instance = new GameObject();
        
        if (ice)
        {
            instance = (GameObject)Instantiate(Resources.Load("basic attack ice"),
            attackPosition, Quaternion.identity) as GameObject;
        }
        else
        {
            instance = (GameObject)Instantiate(Resources.Load("basic attack"),
            attackPosition, Quaternion.identity) as GameObject;
        }


        var instanceRigid = instance.GetComponent<Rigidbody2D>();
        instanceRigid.AddForce(new Vector2(attackSpeed, 0), ForceMode2D.Impulse);

        var script = instance.GetComponent<BasicAttackScript>();
        script.AttackRight();

    }

    public void AttackUpRight()
    {
        
        attackPosition = new Vector3(player.position.x + 1.2f, player.position.y + 0.6f, player.position.z);

        var instance = new GameObject();
        
        if (ice)
        {
            instance = (GameObject)Instantiate(Resources.Load("basic attack ice"),
                attackPosition, Quaternion.identity) as GameObject;
        }
        else
        {
            instance = (GameObject)Instantiate(Resources.Load("basic attack"),
                             attackPosition, Quaternion.identity) as GameObject;

            var script = instance.GetComponent<BasicAttackScript>();
            script.AttackUP();

        }



       
        var instanceRigid = instance.GetComponent<Rigidbody2D>();
        instanceRigid.AddForce(new Vector2(0, attackSpeed), ForceMode2D.Impulse);
       
       

    }

    public void upButton()
    {
       
            up = !up;
         
    }


    public void AttackUpLeft()
    {

        attackPosition = new Vector3(player.position.x - 1.2f, player.position.y + 0.6f, player.position.z);


        var instance = new GameObject();

        
        if (ice)
        {
             instance = (GameObject)Instantiate(Resources.Load("basic attack ice"),
                 attackPosition, Quaternion.identity) as GameObject;
        }
        else
        {
            instance = (GameObject)Instantiate(Resources.Load("basic attack"),
                             attackPosition, Quaternion.identity) as GameObject;
            var script = instance.GetComponent<BasicAttackScript>();
            script.AttackUP();
        }
     



        
        var instanceRigid = instance.GetComponent<Rigidbody2D>();
        instanceRigid.AddForce(new Vector2(0, attackSpeed), ForceMode2D.Impulse);



    }

    public void Attack()
    {
        if (Input.GetKey(KeyCode.W))
        {
            AnimationClass.AttackUp();
        }
        else {
            AnimationClass.Attack();
        }
            //we wait a little before attack
            StartCoroutine(AttackWait());
    }

    //check where the player is looking
    IEnumerator AttackWait()
    {
        yield return new WaitForSeconds(0.2f);
       
            if (Input.GetKey(KeyCode.W) && sprite.flipX || up && sprite.flipX)
            {
                AttackUpLeft();
            }
            else if (Input.GetKey(KeyCode.W) && !sprite.flipX || up && !sprite.flipX)
            {
                AttackUpRight();
            }
            else if (sprite.flipX)
            {
                AttackLeft();

            }
            else
            {
                AttackRight();

            }
        
    }

    //set ice or fire
    void OnTriggerEnter2D(Collider2D coll)
    {

        if (coll.gameObject.tag == "Fire Pick")
        {
            ice = false;  
            liveBar.ProyectileType(ice);
        }

        if (coll.gameObject.tag == "Ice Pick")
        {

            ice = true;
            liveBar.ProyectileType(ice);
        }
    }

    }
