using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using static DataManager;


#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuHandler : MonoBehaviour
{
    public TMP_Text HighScoreText;
    public TMP_InputField UserNameInput;

    void Start()
    {
        ShowHighScore();
    }

    public void StartNew()
    {
        SceneManager.LoadScene(1);
        SetCurrentUserName();
    }

    public void Exit()
    {
        Instance.SaveData(); 

        #if UNITY_EDITOR
            EditorApplication.ExitPlaymode();
        #else
            Application.Quit(); // original code to quit Unity player
        #endif
    }

    public void SetCurrentUserName()
    {
        Instance.currentUser = UserNameInput.text;
    }

    void ShowHighScore(){
        UserData userData = Instance.userData;
        HighScoreText.text = $"High Score : {userData.UserName} : {userData.HighScore}";
    }
}
