using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetHurtBoss : MonoBehaviour {

    public int hp = 3;
    bool groundMonster;

    public BossReaction ReactionClass;

    // Use this for initialization
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "Basic Attack")
        {

            Debug.Log("here");
            hp = hp - 1;

            if (hp == 0)
            {
                ReactionClass.BossDead();
            }
        }
    }


    //trick to know if it is a flying monster or not
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            groundMonster = true;
        }
    }


}


