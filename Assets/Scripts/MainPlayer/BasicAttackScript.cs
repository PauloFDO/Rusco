using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicAttackScript : MonoBehaviour {
    GameObject thisAttack;
    SpriteRenderer sprite;
    // Use this for initialization
    public Animator animate;

    void Start () {

        thisAttack = GetComponent<GameObject>();
        //we use this to flip the sprite
        sprite = GetComponent<SpriteRenderer>();
        animate = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}


   public void AttackLeft()
    {
        sprite = GetComponent<SpriteRenderer>();
        sprite.flipX = true;
    }

    public void AttackRight()
    {

        sprite = GetComponent<SpriteRenderer>();
        sprite.flipX = false;

    }

    public void AttackUP()
    {
        animate = GetComponent<Animator>();
        animate.SetBool("up", true);
       

    }


    public void OnCollisionEnter2D(Collision2D collision)
    {

        animate.SetTrigger("hit");
        StartCoroutine(Hit());
    }

    IEnumerator Hit()
    {
        yield return new WaitForSeconds(0.2f);

       
        Destroy(gameObject);
    }
}
