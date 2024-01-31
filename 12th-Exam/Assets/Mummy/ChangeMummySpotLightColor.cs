using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.UIElements;
using TMPro;
using Unity.VisualScripting;


public class ChangeMummySpotLightColor : MonoBehaviour
{
    static private Light spotLight;

    void Start()
    {
        spotLight = GetComponent<Light>();
    }

    static public void ToGreen()
    {
        spotLight.color = Color.green;
    }

    static public void ToRed()
    {
        spotLight.color = Color.red;
    }
}
