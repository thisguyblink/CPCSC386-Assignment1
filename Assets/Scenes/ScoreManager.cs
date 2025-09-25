using UnityEngine;
using TMPro; 
using UnityEngine.SceneManagement; 

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;
    public int score = 0;
    private int multiplier = 1;
    
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
        score += multiplier;
        scoreText.text = "Score: " + score;

    }

    public void Multiplier()
    {
        multiplier += 1;
    }


    public void ResetScore()
    {
        score = 0;
    }

    
}
