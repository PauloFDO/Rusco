using Narrate;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossReaction : MonoBehaviour {

    public Animator animate;
    public BossAttack EnableDisableAttacks1;
    public BossAttack EnableDisableAttacks2;

    public OnEnableNarrationTrigger TriggerDefeat;

    public GameObject HeadAnimation;
    Animator headReaction;

    // Use this for initialization
    void Start () {
        animate = GetComponent<Animator>();
        headReaction = HeadAnimation.GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update () {
		
	}


    public void BossDead()
    {
        EnableDisableAttacks1.EnableDisableAttacks();
        EnableDisableAttacks2.EnableDisableAttacks();
        DesactivateCollider();

        Debug.Log("boss dead");
        TriggerDefeat.OnEnable(true);
        headReaction.SetBool("laugh", true);
        this.animate.SetBool("Appear", false);
    }

    //when the boss come in and out we turn off the colliders
    void DesactivateCollider()
    {
        BoxCollider2D[] colls = this.GetComponentsInChildren<BoxCollider2D>();

        foreach (var c in colls)
        {
            c.enabled = false;
        }

    }

    void ActivateCollider()
    {
        BoxCollider2D[] colls = this.GetComponentsInChildren<BoxCollider2D>();
        foreach (var c in colls)
        {
            c.enabled = true;
        }
    }


    //check if enemy hit you
    void OnTriggerEnter2D(Collider2D coll)
    {

        if (coll.gameObject.tag == "Player")
        {
            
            DesactivateCollider();
            headReaction.SetBool("laugh", true);
            this.animate.SetBool("Appear", true);          
        }
        StartCoroutine(ActivateCat());

    }

    IEnumerator ActivateCat()
    {

        yield return new WaitForSeconds(14f);
        headReaction.SetBool("laugh",false);
        EnableDisableAttacks1.EnableDisableAttacks();
        EnableDisableAttacks2.EnableDisableAttacks();

        StartCoroutine(ActivateColliderTime());
       
     
    }

    IEnumerator ActivateColliderTime()
    {

        yield return new WaitForSeconds(2f);
        ActivateCollider();
    }



    }
