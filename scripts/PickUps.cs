using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUps : MonoBehaviour
{
    //the pick up game objects
    public GameObject umbrella;
    public GameObject umbrellaEffect;

    public GameObject dashPickUp;
    public GameObject dashPickUpEffect;

    //thing to call non static funcitons
    public static PickUps PU;

    
    void Start()
    {
        //make sure if the player dies or level is reloaded the umbrella can be re picked up
        //I know this can be done by getting a variable to each so I dont have to fetch it each time 
        //but since its only a single level where pickups are needed it won't matter
        umbrella.GetComponent<Collider2D>().enabled = true;
        umbrella.GetComponent<SpriteRenderer>().enabled = true;
        umbrellaEffect.GetComponent<Renderer>().enabled = true;

        dashPickUp.GetComponent<Collider2D>().enabled = true;
        dashPickUp.GetComponent<SpriteRenderer>().enabled = true;
        dashPickUpEffect.GetComponent<Renderer>().enabled = true;

        PU = this;
    }

    
    void Update()
    {
        
    }

    //called by the player movement script when umbrella pick up is taken
    public void UmbrellaTake()
    {
        
        //shakes the screen and sets the components to make it invis and not rendered
        CamShake.CS.ScreenShake();
        umbrella.GetComponent<Collider2D>().enabled = false;
        umbrella.GetComponent<SpriteRenderer>().enabled = false;
        umbrellaEffect.GetComponent<Renderer>().enabled = false;
        
    }

    //called by the player movement script when dash pick up is taken
    public void DashTake()
    {
        //shakes the screen and sets the components to make it invis and not rendered
        CamShake.CS.ScreenShake();
        dashPickUp.GetComponent<Collider2D>().enabled = false;
        dashPickUp.GetComponent<SpriteRenderer>().enabled = false;
        dashPickUpEffect.GetComponent<Renderer>().enabled = false;

    }
}
