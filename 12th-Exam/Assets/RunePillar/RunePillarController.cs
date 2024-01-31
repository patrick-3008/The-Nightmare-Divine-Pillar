using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RunePillarController : MonoBehaviour
{
    public Object bryce;
    public Object mummy;
    public GameObject runePillar;

    void Start()
    {
        Vector3 randomPoitsion = new Vector3(Random.Range(50, 200), 1, Random.Range(60, 100));
        runePillar.transform.position = randomPoitsion;
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("Bryce") && bryce.GetComponent<PlayerMove>().lives > 0)
        {
            WinText.changeToWinText();
            mummy.GetComponent<MummyController>().mummyAnimation.SetBool("isDead", true);
        }
    }
}
