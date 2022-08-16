using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;


public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public string userName;
    public int score = 0;
    public int maxScore;
    public string maxUserName;

    [System.Serializable]
    public class SaveData{
        public string userName;
        public int maxScore;
    }

    void Awake(){
        if(Instance != null){
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
        LoadScore();
    }

    
    public void SaveScore(int score)
    {
        if(score > maxScore){
            SaveData data = new SaveData();
            data.maxScore = score;
            data.userName = userName;

            string json = JsonUtility.ToJson(data);

            File.WriteAllText(Application.persistentDataPath + "/saveFile.json", json);
        }
    }

    public void LoadScore(){
        string path = Application.persistentDataPath + "/saveFile.json";

        if(File.Exists(path)){
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            maxScore = data.maxScore;
            maxUserName = data.userName;
        }else{
            maxScore = 0;
            maxUserName = "";
        }
    }
}
