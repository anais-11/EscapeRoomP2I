using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;

    void Start()
    {
        slider = FindObjectOfType<Slider>();
    }

    public void SetMaxHealth(int value)
    {
        slider.maxValue = value;
        slider.value = value;
    }

    public void SetHealth(int value)
    {
        Debug.Log("bar ok");
        slider.value = value;
    }
}
