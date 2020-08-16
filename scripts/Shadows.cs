using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shadows : MonoBehaviour
{

    public GameObject[] array;
    public GameObject shadow1;
    public GameObject umbrellaShadow;
    public GameObject[] shadows;
    public BoxCollider2D shadowCollider;
    public static Shadows S;
    public Renderer umbrellaShadowRend;
    public Renderer umbrellaRend;
    public static bool Ushadow = false;
    
    
    void Start()
    {
        S = this;
        shadow1.GetComponent<Renderer>().material.color = new Color(1.0f, 1.0f, 1.0f, 0.3f);
        
        umbrellaShadowRend.enabled = false;
        umbrellaRend.enabled = false;

        


        for (int i = 0; i < array.Length ; i++)
        {
            //creates shadows for each platform using their vector3
            Vector3 temp = array[i].transform.position;
            Vector3 fixPos = temp + (new Vector3(0, -15, 0));
            shadows[i] = Instantiate(shadow1, fixPos, Quaternion.identity);
            
        }

    }

    public void TurnOnUShadow()
    {
        Ushadow = true;
        
        umbrellaShadowRend.enabled = true;
        umbrellaRend.enabled = true;
        umbrellaShadow.GetComponent<Renderer>().material.color = new Color(1.0f, 1.0f, 1.0f, 0.2f);
        
        HealthBar.HB.UHealthDown();
        HealthBar.HB.UHealthUp();

    }

    public void TurnOffUShadow()
    {
        Ushadow = false;
        
        umbrellaShadowRend.enabled = false;
        umbrellaRend.enabled = false;

        
        HealthBar.HB.UHealthUp();
        HealthBar.HB.UHealthDown();

    }

    public void TurnoffU()
    {
        umbrellaShadowRend.enabled = false;
        umbrellaRend.enabled = false;
        Ushadow = false;
        HealthBar.HB.UHealthUp();
        HealthBar.HB.UHealthDown();

    }










}
