using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class LightBehavior : MonoBehaviour
{
    new Light2D light;
    void Start()
    {
        light = GetComponent<Light2D>();   
    }

    public void IncreaseIntensity()
    {
        light.intensity += .1f;
    }
}
