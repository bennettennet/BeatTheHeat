using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSprite : MonoBehaviour
{
    //different skins for player
    public Sprite normal;
    public Sprite burnt;
    private SpriteRenderer rend;
    public static PlayerSprite PS;

    void Start()
    {
        //intiating stuff
        PS = this;
        rend = GetComponent<SpriteRenderer>();
    }

    
    //changes the player skin to the burnt one and stops the player moving
    public void GetBurnt()
    {
        rend.sprite = burnt;
        PlayerMovement.stasis = true;
    }
    //changes the skin to the defualt one
    public void GetNormal()
    {
        rend.sprite = normal;
    }

}
