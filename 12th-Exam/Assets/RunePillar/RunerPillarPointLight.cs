using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RunerPillarPointLight : MonoBehaviour
{
    private Light pointLight;

    private float maxRange = 50f;
    private float minRange = 0f;
    private float currentRange;
    private float targetRange = 50f;
    public float deltaSpeed = 25.0f;

    void Start()
    {
        pointLight = GetComponent<Light>();
    }

    void Update()
    {
        currentRange = Mathf.MoveTowards(pointLight.range, targetRange, Time.deltaTime * deltaSpeed);
        if (currentRange >= maxRange)
        {
            currentRange = maxRange;
            targetRange = minRange;
        }
        else if (currentRange <= minRange)
        {
            currentRange = minRange;
            targetRange = maxRange;
        }

        pointLight.range = currentRange;
    }
}
