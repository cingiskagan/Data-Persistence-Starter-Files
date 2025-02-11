using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    [HideInInspector]
    public static DataManager Instance;
    [HideInInspector]
    public UserData userData;
    [HideInInspector]
    public string currentUser;

    private void Awake()
    {
        userData = new UserData();

        if(Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
        LoadData();
    }

    [System.Serializable]
    public class UserData
    {
        public string UserName;
        public int HighScore;
    }

    public void SaveData()
    {
        string json = JsonUtility.ToJson(userData);
        string path = Application.persistentDataPath + "/savefile.json";
        Debug.Log("write");
        Debug.Log(json);
    
        File.WriteAllText(path, json);
    }

    public void LoadData()
    {
        string path = Application.persistentDataPath + "/savefile.json";

        Debug.Log("read");
        Debug.Log(path);

        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            Debug.Log(json);
            UserData data = JsonUtility.FromJson<UserData>(json);

            userData = data;
        }
    }
}
