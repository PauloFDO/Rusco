using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainPlayerLiveBar : MonoBehaviour {

   Animator damageSprites;

    // Use this for initialization
    void Start () {
        damageSprites = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Damage(int totalDamage)
    {
        
        damageSprites.SetInteger("Damage", totalDamage);
    }

    public void ProyectileType(bool Type)
    {
        //if its true is ice if its false if fire
        damageSprites.SetBool("Ice", Type);
    }
}
