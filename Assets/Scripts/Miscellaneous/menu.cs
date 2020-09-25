using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menu : MonoBehaviour {

    public GameObject Canvas;

    //dead screen button apear and disapear in "main player animations"

    // Use this for initialization
    void Start()
    {



    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("escape"))
        {
            SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
        }
    }

    //dead button functions

    public void Retry()
    {
        SceneManager.LoadScene("RuscoSave", LoadSceneMode.Single);
        Time.timeScale = 1F;
    }


    public void Exit()
    {
        Application.Quit();
    }
}
