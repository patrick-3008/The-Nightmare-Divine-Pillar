using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class MummyAlertLevel : MonoBehaviour
{
    public Object mummy;
    private TextMeshProUGUI alertLevel;
    void Start()
    {
        alertLevel = GetComponent<TextMeshProUGUI>();
    }
    void Update()
    {
        alertLevel.text = "Alert Level: " + mummy.GetComponent<MummyController>().alertLevel.ToString("f1");
    }
}
