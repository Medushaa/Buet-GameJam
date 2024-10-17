using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    private float score = 0f;
    private bool isGamePaused = false;

    void Update()
    {
        if (!isGamePaused)
        {
            score += Time.deltaTime; 
            scoreText.text = "Score: " + Mathf.FloorToInt(score);
        }
    }

    public void PauseGame()
    {
        isGamePaused = true;
        Time.timeScale = 0f; 
    }

    public void ResumeGame()
    {
        isGamePaused = false;
        Time.timeScale = 1f; 
    }
}
