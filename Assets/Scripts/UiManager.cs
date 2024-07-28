using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    public Text highScoreText;

    private void Start()
    {
        PersistenceManager.Instance.LoadPlayerData();
        UpdateHighScoreText();
    }

    public void OnPlayerNameChanged(string newName)
    {
        PersistenceManager.Instance.PlayerNameInput = newName;
    }

    public void OnStartGame()
    {
        PersistenceManager.Instance.LoadPlayerData();
        SceneManager.LoadScene(1);
    }

    private void UpdateHighScoreText()
    {
        highScoreText.text =
            $"High Score: {PersistenceManager.Instance.HighScore} by {PersistenceManager.Instance.PlayerNameHighscore}";
    }
}
