using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    // VARIABLES
    [SerializeField]
    public Slider slider;
    [SerializeField] 
    public Gradient gradient;
    [SerializeField]
    public Image fill; 

    public void setMaxHealth(int health)
    {
        slider.maxValue = health; 
        slider.value = health; 
        fill.color = gradient.Evaluate(1f);
    }

    public void setHealth(int health)
    {
        slider.value = health;
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }
}
