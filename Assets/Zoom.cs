using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zoom : MonoBehaviour
{
    public float sensitivity = 1;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        float scrollChange =
            Input.GetAxis(
                "Mouse ScrollWheel"); //This little peece of code is written by JelleWho https://github.com/jellewie
        if (Math.Abs(scrollChange) > 0.1)
        {
            var main_camera = Camera.main;
            main_camera.orthographicSize = main_camera.orthographicSize - scrollChange * sensitivity;
        }
    }
}