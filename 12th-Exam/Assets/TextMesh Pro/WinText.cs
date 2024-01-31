using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class WinText : MonoBehaviour
{
    static private TextMeshProUGUI alertLevel;

    void Start()
    {
        alertLevel = GetComponent<TextMeshProUGUI>();
        alertLevel.text = "";
    }

    static public void changeToWinText()
    {
        alertLevel.text = "Victory !";
    } 
}
