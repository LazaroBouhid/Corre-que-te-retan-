using UnityEngine;
using TMPro;

public class BestRecordUI : MonoBehaviour
{
    public TextMeshProUGUI bestText;

    void Start()
    {
        float best = PlayerPrefs.GetFloat("BestScore", 0);
        bestText.text = "BEST " + Mathf.FloorToInt(best) + " Seg";
    }
}