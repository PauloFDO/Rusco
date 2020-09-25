using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CowardEnemy : MonoBehaviour {

    public int Speed = 10;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        MoveToTouchPlayer();
    }


    public void MoveToTouchPlayer()
    {

        var Player = GameObject.FindGameObjectsWithTag("Player");
        transform.position = Vector3.MoveTowards(transform.position, Player[0].transform.position, Speed * Time.deltaTime);
    }

}