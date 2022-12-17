using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    private string userName;
    private string bestName;
    private int bestScore;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
        LoadName();
    }
    private void SetBestScore(string name, int score) {
        bestScore = score;
        bestName = name;
    }

    public void Save()
    {
        SaveData data = new SaveData();
        data.name = userName;
        data.bestName = bestName;
        data.bestScore = bestScore;

        string json = JsonUtility.ToJson(data);
    
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadName()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            userName = data.name;
            SetBestScore(data.bestName, data.bestScore);
        }
    }

    public void SetUserName(string user) {
        userName = user;
    }


    public string GetBestScore() {
        return "Best score: " + bestName + " : " + bestScore;
    }

    public void ResolveBestScore(int score) {
        if(score >= bestScore) {
            SetBestScore(userName, score);
            Save();
        }
    }
}

[System.Serializable]
class SaveData
{
    public string name;
    public string bestName;
    public int bestScore;
}

