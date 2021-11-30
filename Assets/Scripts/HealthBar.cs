﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] Slider slider;
    public void SetHealth(float _currentHealth)
    {
        slider.value = _currentHealth;
    }
}
