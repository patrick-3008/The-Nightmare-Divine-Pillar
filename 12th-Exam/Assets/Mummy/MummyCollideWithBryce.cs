using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MummyCollideWithBryce : MonoBehaviour
{
    public Object bryce;
    public Object mummy;

    private float timeToLookAway = 0.0f;
    private bool counting = false;

    void Update()
    {
        if (counting)
            timeToLookAway += 1.0f * Time.deltaTime;

        if (timeToLookAway > 4)
        {
            mummy.GetComponent<MummyController>().rotateMummyToLookAway();
            counting = false;
            timeToLookAway = 0;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bryce") && (bryce.GetComponent<PlayerMove>().bryceAnimation.GetBool("isWalking")
            || bryce.GetComponent<PlayerMove>().bryceAnimation.GetBool("isJumping")))
        {
            Debug.Log("Bryce seen in the red zone");
            counting = true;

            bryce.GetComponent<PlayerMove>().bryceAnimation.SetBool("isHitted", true);
            bryce.GetComponent<PlayerMove>().lives--;
            mummy.GetComponent<MummyController>().mummyAnimation.SetBool("isDancing", true);
            mummy.GetComponent<MummyController>().alertLevel += 100.0f;
            ChangeMummySpotLightColor.ToRed();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Bryce"))
        {
            Debug.Log("Bryce left the red zone");

            bryce.GetComponent<PlayerMove>().bryceAnimation.SetBool("isHitted", false);
            mummy.GetComponent<MummyController>().mummyAnimation.SetBool("isDancing", false);
            ChangeMummySpotLightColor.ToGreen();
        }
    }

}
