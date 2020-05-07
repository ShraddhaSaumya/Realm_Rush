﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] int health = 10;
    [SerializeField] int healthDeacrease = 1;
    [SerializeField] Text healthText;

    private void Start()
    {
        healthText.text = health.ToString();
    }

    private void OnTriggerEnter(Collider other)
    {
        health = health - healthDeacrease;
        healthText.text = health.ToString();
    }
}
