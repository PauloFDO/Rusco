using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour {

    public static int checkPointTriggered;
    public static Vector3 checkPointTriggeredPosition;


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag.Equals("Player"))
        {
            var checkPointnumber = Convert.ToInt32(gameObject.name);
            Debug.Log("checked");
            if (checkPointnumber > checkPointTriggered)
            {
                checkPointTriggered = checkPointnumber;
                checkPointTriggeredPosition = gameObject.transform.position;
            }

        }
    }
}
