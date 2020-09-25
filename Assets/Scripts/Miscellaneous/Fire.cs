using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour {

	// Use this for initialization
	void Start () {
        StartCoroutine(Disappear());
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    IEnumerator Disappear()
    {
        yield return new WaitForSeconds(1f);


        Destroy(gameObject);

    }

    }
