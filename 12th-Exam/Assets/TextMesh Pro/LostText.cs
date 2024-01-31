using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class LostText : MonoBehaviour
{
    static private TextMeshProUGUI alertLevel;

    void Start()
    {
        alertLevel = GetComponent<TextMeshProUGUI>();
        alertLevel.text = "";
    }

    static public void changeToLostText()
    {
        alertLevel.text = "You Died !";
    }
}
