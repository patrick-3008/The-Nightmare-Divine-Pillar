using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class MummyController : MonoBehaviour
{
    public CharacterController mummyController;
    public Object bryce;
    public Animator mummyAnimation;

    public float alertLevel = 100.0f;
    private float noRotationTime = 0.0f;
    private float randomTimeAfterReady = 0;
    private bool readyToRotate = false;
    private float rotationSpeed;
    private bool get1TimeRandom = true;
    int rndFrom1To50;

    void Start()
    {
        mummyController = GetComponent<CharacterController>();
        mummyAnimation = GetComponent<Animator>();
        rotationSpeed = alertLevel * Time.deltaTime;
    }


    void Update()
    {
        if (alertLevel > 0)
            alertLevel -= 1.0f * Time.deltaTime;

        logicForRotation();
    }

    void logicForRotation()
    {
        noRotationTime += 1.0f * Time.deltaTime;

        if (noRotationTime > 10.0f)
        {
            readyToRotate = true;
            get1TimeRandom = false;
        }
        if (get1TimeRandom)
            rndFrom1To50 = Random.Range(0, 50);

        if (readyToRotate)
        {
            randomTimeAfterReady += Time.deltaTime;
            if (rndFrom1To50 == (int)randomTimeAfterReady)
            {
                if (transform.localRotation.eulerAngles.y == 180)
                    rotateMummyToLookAway();
                else
                    rotateMummyToLookToBryce();
            }
        }
    }

    void rotateMummyToLookToBryce()
    {
        transform.rotation = Quaternion.Euler(0, 180, 0);
        noRotationTime = randomTimeAfterReady = 0.0f;
        readyToRotate = false;
        get1TimeRandom = true;
        mummyAnimation.SetBool("isLooking", true);
    }

    public void rotateMummyToLookAway()
    {
        Debug.Log("Rotation Called");
        mummyAnimation.SetBool("isLooking", false);
        mummyAnimation.SetBool("isDancing", false);
        noRotationTime = randomTimeAfterReady = 0.0f;
        readyToRotate = false;
        get1TimeRandom = true;
        transform.rotation = Quaternion.Euler(0, 0, 0);
    }
}
