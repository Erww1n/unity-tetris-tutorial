using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public TMP_Text scoreText; // Для TextMeshPro
    private int score = 0; // Текущий счёт

    void Start()
    {
        if (scoreText == null)
        {
            GameObject textObject = GameObject.Find("ScoreText");
            if (textObject != null)
            {
                scoreText = textObject.GetComponent<TMP_Text>();
            }
            else
            {
                Debug.LogError("Не удалось найти объект ScoreText!");
                return;
            }
        }

        UpdateScoreText();
    }

    public void AddScore(int points)
    {
        score += points;
        UpdateScoreText();
    }

    private void UpdateScoreText()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score.ToString();
        }
        else
        {
            Debug.LogError("ScoreText не подключён!");
        }
    }
}
