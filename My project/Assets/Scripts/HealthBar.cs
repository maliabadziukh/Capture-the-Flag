using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    private Image healthBar;
    
    private void Start()
    {
        healthBar = GetComponent<Image>();
    }

    public void UpdateHealthBar(float newValue)
    {
        healthBar.fillAmount = newValue;
    }
}
