using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{

    //the slider controlling the health bar ui
    public Slider slider;
    public Gradient gradient;
    //the full health bar image
    public Image fill;
    public Image Icon;
    //float representing a full health bar
    private float top = 1f;
    public static HealthBar HB;

    private void Start()
    {
        //intiating variables
        HB = this;
        SetMaxHealth(1);
        
    }
    
    //reduces the length of the health bar by repeatingly calling a function below
    public void UHealthDown()
    {
        //if the umbrella is on the health bar goes down
        //else it stops going down
        if (Shadows.Ushadow == true)
        {
            InvokeRepeating("DecreaseHealth", 0f, 0.025f);
        }
        else
        {
            CancelInvoke("DecreaseHealth");
        }

    }

    //increases the length of health bar by repeatingly calling a function below
    public void UHealthUp()
    {

        //if the umbrella is off the health bar goes up
        //else it stops going up
        if (Shadows.Ushadow == false)
        {
            InvokeRepeating("IncreaseHealth", 0f, 0.02f);

        }
        else
        {
            CancelInvoke("IncreaseHealth");
        }
            
    }

    //called after restart to set health of umbrella to full
    public void SetMaxHealth(int health)
    {

        slider.maxValue = health;
        slider.value = health;

        fill.color = gradient.Evaluate(1f);
    }

    //function called by Uhealthdown to call setHealth to reduce health bar
    private void DecreaseHealth()
    {
        //reduces health bar until 0 (empty) where it stops
        if (Shadows.Ushadow == true && top >= 0)
        {
            top = top - 0.005f;
            SetHealth(top);
        }
        if (top <= 0)
        {
            Shadows.S.TurnoffU();
        }

        
        
        
    }

    //function called by Uhealthup to call setHealth to increase health bar
    private void IncreaseHealth()
    {
        //increase health bar until 1 (full) where it stops
        if (Shadows.Ushadow == false && top <= 1)
        {
            top = top + 0.01f;
            SetHealth(top);
        }
        

    }

    //called by the two functions above to set the slider to a different value
    public void SetHealth(float health)
    {
        slider.value = health;

        Umbrella.U.UDmgChange(health);

        fill.color = gradient.Evaluate(slider.normalizedValue);
        Icon.color = gradient.Evaluate(slider.normalizedValue);
    }



}
