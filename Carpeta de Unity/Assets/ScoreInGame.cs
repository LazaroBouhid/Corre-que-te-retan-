using UnityEngine;
using TMPro;

public class ScoreInGame : MonoBehaviour
{
    public TextMeshProUGUI scoreText;

    public float score;
    public float speed = 1f;

    float bestScore;

    void Start()
    {
        bestScore = PlayerPrefs.GetFloat("BestScore", 0);
        score = 0;
    }

    void Update()
    {
        score += speed * Time.deltaTime;

        scoreText.text = Mathf.FloorToInt(score) + " Seg";

        if (score > bestScore)
        {
            bestScore = score;
            PlayerPrefs.SetFloat("BestScore", bestScore);
        }
    }

    void OnApplicationQuit()
    {
        PlayerPrefs.Save();
    }
}