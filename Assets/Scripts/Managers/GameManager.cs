using UnityEngine;
using TMPro;
using System.Collections;

public class GameManager : MonoBehaviour
{
    [SerializeField] PlayerController playerController;
    [SerializeField] TMP_Text timeText;
    [SerializeField] GameObject gameOverText;
    [SerializeField] float startTime = 5f;
    float timeLeft;
    bool gameOver = false;

    public bool GameOver => gameOver;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        timeLeft = startTime;
    }

    // Update is called once per frame
    void Update()
    {
        DecreaseTime();
    }

    private void DecreaseTime()
    {
        if (gameOver) return;
        timeLeft -= Time.deltaTime;
        timeText.text = timeLeft.ToString("F1");

        if (timeLeft <= 0f)
        {
            PlayerGameOver();
        }
    }

    void PlayerGameOver()
    {
        gameOver = true;
        playerController.enabled = false;
        Time.timeScale = .1f;
        gameOverText.SetActive(true);
    }
}
