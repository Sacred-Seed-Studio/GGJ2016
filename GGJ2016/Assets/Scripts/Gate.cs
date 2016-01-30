﻿using UnityEngine;
using System.Collections;

public class Gate : MonoBehaviour
{

    public GameObject leftGate, rightGate;

    float totalTimeToTake = 2f;
    float inc = 0.01f;

    Vector2 p;

    void OnTriggerStay2D(Collider2D other)
    {
        if (GameController.controller.openGate)
        {
            GameController.controller.openGate = false;
            GameController.controller.correctPedestalsTouched = 0;
            StartCoroutine(OpenGates());
        }
    }


    IEnumerator OpenGates()
    {
        float timeTaken = 0;

        while (timeTaken < totalTimeToTake)
        {
            p = leftGate.transform.position;
            p.x -= inc;
            leftGate.transform.position = p;
            p = rightGate.transform.position;
            p.x += inc;
            rightGate.transform.position = p;
            timeTaken += inc;
            yield return null;
        }

        yield return null; 
    }
}
