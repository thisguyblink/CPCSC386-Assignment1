using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenu : MonoBehaviour
{
    private TMP_Text scoreText;
    void Start()
    {
        scoreText = GameObject.Find("ScoreText").GetComponent<TMP_Text>();
        if (ScoreManager.Instance == null)
        {
            GameObject go = new GameObject("ScoreManager");
            go.AddComponent<ScoreManager>();
        }
        if (scoreText == null)
        {
            Debug.LogWarning("Score Text is not assigned!");
            return;
        }
        if (ScoreManager.Instance.score > 0)
        {
            scoreText.text = "Game Over\n Final Score: " + ScoreManager.Instance.score;
        }
        else
        {
            scoreText.text = "Ready to Play???";
        }
    }
    public void PlayGame()
    {
        // Replace "GameScene" with your gameplay scene name
        Debug.Log("Play Game Button Pressed");
        ScoreManager.Instance.ResetScore();
        SceneManager.LoadScene("Level-1");
    }

    public void QuitGame()
    {
        Debug.Log("Quit Game!");
        Application.Quit();

        // Note: Quit won’t stop play mode in the Unity editor
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
    

    

}
