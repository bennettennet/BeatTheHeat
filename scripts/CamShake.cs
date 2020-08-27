using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamShake : MonoBehaviour
{
    private Animation shake;

    //thing that lets me call non static variables
    public static CamShake CS;
    
    void Start()
    {
        //initiates stuff
        CS = this;
        shake = gameObject.GetComponent<Animation>();
    }
    
    //funciton which is called in order to make the screen shake
    public void ScreenShake()
    {
        shake.Play();
    }

}
