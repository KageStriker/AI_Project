﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    private Animator anim;

    public Canvas canvas;
    public Text staminaText;
    public Text energyText;
    public Text reputationText;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    
}