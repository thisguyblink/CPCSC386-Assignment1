using UnityEngine;
using TMPro; 

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;
    public int score = 0;
    
    private TMP_Text scoreText;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        scoreText = GameObject.Find("ScoreText").GetComponent<TMP_Text>();
    }

    public void AddScore()
    {
        scoreText = GameObject.Find("ScoreText")?.GetComponent<TMP_Text>();
        score += 1;
        scoreText.text = "Score: " + score;

    }


    public void ResetScore()
    {
        score = -1;
    }

    
}
