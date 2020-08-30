using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingCube : MonoBehaviour
{
    //direction the cube is moving true is right
    private bool directionR = true;

    public GameObject cube;
    private Rigidbody2D rb;

    //private GameObject movingShadow;

    //speed at which platforms move
    private float platformSpeed = 10;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //movingShadow = Instantiate(Shadows.S.shadow1, new Vector3(0, -15, 0), Quaternion.identity);
        //movingShadow.transform.localScale = new Vector3(cube.transform.localScale.x, movingShadow.transform.localScale.y, movingShadow.transform.localScale.z);
    }

    // Update is called once per frame
    void Update()
    {
        //movingShadow.position
        if (directionR)
        {
            rb.velocity = new Vector2(platformSpeed, rb.velocity.y);
        }
        else
        {
            rb.velocity = new Vector2(-platformSpeed, rb.velocity.y);
        }

        

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.tag == ("platform"))
        {
            SwitchDirection();
        }
    }
    
    void SwitchDirection()
    {
        directionR = !directionR;
    }
}
