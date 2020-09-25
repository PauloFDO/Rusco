using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class laghinheadPosition : MonoBehaviour {

    public Transform headPosition;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

       var head = new Vector3(headPosition.position.x-1.6f, headPosition.position.y + 5.6f);
        transform.position = head;
	}
}
