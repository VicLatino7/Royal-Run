using UnityEngine;
using TMPro;
public class ScoreManager : MonoBehaviour
{
    [SerializeField] GameManager gameManager;
    [SerializeField] TMP_Text scoreText;

    int score = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void IncreaseScore(int amount)
    {
        if (gameManager.GameOver) return;
        score += amount;
        scoreText.text = score.ToString();
    }
}
