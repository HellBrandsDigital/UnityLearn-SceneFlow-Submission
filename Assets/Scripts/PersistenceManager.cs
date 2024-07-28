using System;
using System.IO;
using UnityEngine;

public class PersistenceManager : MonoBehaviour
{
    public string PlayerNameInput = "";
    public string PlayerNameHighscore = "None";
    public int HighScore = -1;
    public static PersistenceManager Instance { get; private set; }


    private void Awake()
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
    }

    public void SavePlayerData()
    {
        SaveData data = new SaveData
        {
            playerName = PlayerNameHighscore,
            highScore = HighScore
        };

        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadPlayerData()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (!File.Exists(path)) return;

        string json = File.ReadAllText(path);
        SaveData data = JsonUtility.FromJson<SaveData>(json);
        PlayerNameHighscore = data.playerName;
        HighScore = data.highScore;
    }

    [Serializable]
    private class SaveData
    {
        public string playerName;
        public int highScore;
    }
}
