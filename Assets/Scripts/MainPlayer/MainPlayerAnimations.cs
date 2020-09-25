using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainPlayerAnimations : MonoBehaviour {

   public Animator animate;
    //dead canvas
    public GameObject Canvas;

    // Use this for initialization
    void Start () {
        //animation control
        animate = GetComponent<Animator>();

        if (Canvas != null)
        {
            Canvas.SetActive(false);
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    //run controls
    public void Run()
    {
        animate.SetBool("run", true);
    }

    public void StopRun()
    {
        animate.SetBool("run", false);
    }

    //jump controls
    public void jump()
    {
        //we may be attacking in the air!
        animate.ResetTrigger("attack");
        animate.SetBool("jump", true);
    }


    public void EndJump()
    {
        animate.SetBool("jump", false);
        animate.SetTrigger("touch floor");
    }


    public void EndJumpTriggerReset()
    {
        
        animate.ResetTrigger("touch floor");
    }

    public void Attack()
    {
        animate.SetTrigger("attack");
    }

    public void AttackUp()
    {
        animate.SetTrigger("attackUp");
    }

    //check if enemy hit you
    void OnCollisionEnter2D(Collision2D coll)
    {
        
        if(coll.gameObject.tag == "Enemy")
        {
            animate.SetTrigger("GetHit");
            StartCoroutine(ResetHit());
        }

    }

    IEnumerator ResetHit()
    {
        yield return new WaitForSeconds(0.5f);

        animate.ResetTrigger("GetHit");
    }


    public void Die()
    {
        animate.SetBool("Die",true);
        Canvas.SetActive(true);
    }

    public void Revive()
    {
        animate.SetBool("Die", false);
        Canvas.SetActive(false);
    }
}
