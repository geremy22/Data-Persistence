using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuUIHandler : MonoBehaviour
{
    public void Play() {
        GameManager.Instance.Save();
        SceneManager.LoadScene(1);
    }

    public void Quit() {
        GameManager.Instance.Save();
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.ExitPlaymode();
        #else
            Application.Quit(); // original code to quit Unity player
        #endif
    }

    public void NameChanged(string userName) {
        GameManager.Instance.SetUserName(userName);
    }
}
