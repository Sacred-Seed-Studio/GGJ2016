﻿using UnityEngine;
using System.Collections;

public class Pedestal : MonoBehaviour
{
    [HideInInspector]
    public SpriteRenderer sr;

    public SpriteRenderer symbolSR;

    public Color activeColor = Color.black;
    public Color inactiveColor = Color.white;
    public Color angryColor = Color.red;
    public PedestalType pType = PedestalType.T1;

    public bool isOn;

    Animator anim;

    void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        symbolSR = GetComponentsInChildren<SpriteRenderer>()[1];
        anim = GetComponent<Animator>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!GameController.controller.torchesVisible) return;
        Debug.Log("Touching pedestal ");
        Activate();
    }

    public void Activate()
    {
        if (isOn) return;
        isOn = true;
        if (GameController.controller.IsCorrectPedestal(pType))
        {
            //sr.color = activeColor;
            GameController.controller.correctPedestalsTouched += 1;
            anim.SetBool("Off", false);
        }
        else
        {
            sr.color = angryColor;
            GameController.controller.TouchedWrongPedestal();
            anim.SetBool("Off", true);
        }
    }

    public void DisActivate()
    {
        isOn = false;
        sr.color = inactiveColor;
        anim.SetBool("Off", true);
    }


    public void Reset()
    {
        DisActivate();
    }

    public void ChangeType(PedestalType p, Sprite s, Color c)
    {
        Debug.Log("Changing type");
        pType = p;
        symbolSR.sprite = s;
        symbolSR.color = c;
    }
}
