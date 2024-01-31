using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class BryceLiveTextUpdater : MonoBehaviour
{
    public Object bryce;
    private TextMeshProUGUI bryceLives;
    void Start()
    {
        bryceLives = GetComponent<TextMeshProUGUI>();
    }
    void Update()
    {
        bryceLives.text = "<size=100> <sprite=0> </size>" + bryce.GetComponent<PlayerMove>().lives.ToString();
    }
}
