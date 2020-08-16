using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Umbrella : MonoBehaviour
{
    //the three stages of damage on the umbrella
    //each one is a seperate sprite
    public Sprite Udmg0;
    public Sprite Udmg1;
    public Sprite Udmg2;

    private SpriteRenderer rend;

    public static Umbrella U;

    void Start()
    {
        //intiating variables
        U = this;
        rend = GetComponent<SpriteRenderer>();

    }

    //changes the value of the umbrella health as its held by player
    public void UDmgChange(float health)
    {
        //changes the umbrella sprite based on its remaining health
        if (health < 0.50 && health > 0.2)
        {
            rend.sprite = Udmg1;

            
        }

        else if (health < 0.2)
        {
            rend.sprite = Udmg2;
        }

        else if( health > 0.5)
        {
            rend.sprite = Udmg0;
        }
    }

    

}
