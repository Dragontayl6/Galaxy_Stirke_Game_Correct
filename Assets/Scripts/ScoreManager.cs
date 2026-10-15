using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance { get; private set; }

    [SerializeField] int score = 0;
    [SerializeField] TMP_Text scoreText;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Debug.LogError("More than one ScoreManager is active in the scene.", this);
            enabled = false;
            return;
        }

        Instance = this;

        if (scoreText == null)
        {
            Debug.LogError("Assign a score text object to the Score Manager's Score Text field.", this);
            return;
        }

        scoreText.text = score.ToString();
    }

    public void AddScore(int amount)
    {
        score += amount;

        if (scoreText != null)
        {
            scoreText.text = score.ToString();
        }
    }
}
