using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;
    public Gradient gradient;
    public Image fill;
    public Image Icon;
    private float top = 1f;
    public static HealthBar HB;

    private void Start()
    {
        HB = this;
        SetMaxHealth(1);
        
    }

    public void UHealthDown()
    {
        if (Shadows.Ushadow == true)
        {
            InvokeRepeating("DecreaseHealth", 0f, 0.025f);
        }
        else
        {
            CancelInvoke("DecreaseHealth");
        }

    }

    public void UHealthUp()
    {
        if (Shadows.Ushadow == false)
        {
            InvokeRepeating("IncreaseHealth", 0f, 0.02f);

        }
        else
        {
            CancelInvoke("IncreaseHealth");
        }
            
    }

    public void SetMaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;

        fill.color = gradient.Evaluate(1f);
    }

    private void DecreaseHealth()
    {
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

    private void IncreaseHealth()
    {
        if (Shadows.Ushadow == false && top <= 1)
        {
            top = top + 0.01f;
            SetHealth(top);
        }
        

    }

    public void SetHealth(float health)
    {
        slider.value = health;

        Umbrella.U.UDmgChange(health);

        fill.color = gradient.Evaluate(slider.normalizedValue);
        Icon.color = gradient.Evaluate(slider.normalizedValue);
    }



}
