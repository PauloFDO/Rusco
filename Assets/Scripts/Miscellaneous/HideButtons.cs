using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HideButtons : MonoBehaviour
{
    public GameObject Canvas;
    MainPlayerAnimations AnimationClass;
    //dead screen button apear and disapear in "main player animations"

    // Use this for initialization
    void Start()
    {
        if (Application.platform != RuntimePlatform.Android)
        {
            Canvas.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    //dead button functions

    public void Retry()
    {
        var player = GameObject.FindGameObjectWithTag("Player");
        var damageScript = player.GetComponent<MainPlayerGetHurt>();
        damageScript.Revive();
        Canvas.SetActive(false);

    }

    public void Exit()
    {
        Application.Quit();
    }
}
