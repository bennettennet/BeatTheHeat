using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shadows : MonoBehaviour
{

    //array of all the platforms to make shadows under
    //currently must manually add the platforms to the array each time I add a new one
    //looking for a solution
    public GameObject[] array;
    //the intial shadows to make copies of for each one
    public GameObject shadow1;
    //umbrella's shadow
    public GameObject umbrellaShadow;
    public GameObject[] shadows;
    //collider to detect when player enters and leaves shadows
    public BoxCollider2D shadowCollider;
    public static Shadows S;
    public Renderer umbrellaShadowRend;
    public Renderer umbrellaRend;
    //player starts with his umbrella off
    public static bool Ushadow = false;

    
    
    
    void Start()
    {
        //intiating variables
        S = this;
        shadow1.GetComponent<Renderer>().material.color = new Color(0f, 0f, 0f, 0.3f);
        
        umbrellaShadowRend.enabled = false;
        umbrellaRend.enabled = false;


        

        //creates a shadow under each platform
        for (int i = 0; i < array.Length ; i++)
        {
            //creates shadows for each platform using their vector3
            Vector3 temp = array[i].transform.position;
            //shadow is 30 units long so must be -15 under each platform to not stick through
            Vector3 fixPos = temp + (new Vector3(0, -15, 0));
            shadows[i] = Instantiate(shadow1, fixPos, Quaternion.identity);
            shadows[i].transform.localScale = new Vector3(array[i].transform.localScale.x, shadow1.transform.localScale.y, shadow1.transform.localScale.z);
            
        }

    }

    //called when player enables their umbrella
    public void TurnOnUShadow()
    {
        Ushadow = true;

        //plays the umbrella up aniamtion from Umbrella script
        Umbrella.U.UmbrellaUpPlay(); 

        umbrellaShadowRend.enabled = true;
        umbrellaRend.enabled = true;
        //changes the transparency of the umbrella shadow so it is now visable to the user
        umbrellaShadow.GetComponent<Renderer>().material.color = new Color(0f, 0f, 0f, 0.2f);

        //calls functions to change health of umbrella, both are called as only the one needed will activate
        HealthBar.HB.UHealthDown();
        HealthBar.HB.UHealthUp();

    }

    //called when player disables their umbrella to play the down animation
    public void TurnOffUShadow()
    {
        Ushadow = false;
        //calls functions to change health of umbrella, both are called as only the one needed will activate
        HealthBar.HB.UHealthUp();
        HealthBar.HB.UHealthDown();
        
        //plays the umbrella down aniamtion from Umbrella script
        Umbrella.U.UmbrellaDownPlay();

    }

   

    //removes the umbrella sprite when the player disables the umbrella
    //This variable may not actually be called anywhere anymore but im too afraid to touch it
    public void TurnoffU()
    {
        umbrellaShadowRend.enabled = false;
        umbrellaRend.enabled = false;
        Ushadow = false;
        HealthBar.HB.UHealthUp();
        HealthBar.HB.UHealthDown();

    }












}
