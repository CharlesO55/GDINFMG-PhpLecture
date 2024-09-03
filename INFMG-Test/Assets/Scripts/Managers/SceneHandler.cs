using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class SceneHandler : MonoBehaviour {
    private static SceneHandler Instance;

    public void OpenLogin() {
        DatabaseManager.GetInstance().LogOut();
        SceneManager.LoadScene("MainMenuScene");
    }

    public void OpenRegister() {
        SceneManager.LoadScene("RegisterScene");
    }

    public void OpenGame() {
        SceneManager.LoadScene("GameScene");
    }

    public void OpenProfile()
    {
        SceneManager.LoadScene("ProfileScene");
    }

    private void Awake() {
        if(Instance == null)
            Instance = this;
        else
            Destroy(this.gameObject);
    }

    public static SceneHandler GetInstance() {
        if(Instance == null) {
            Instance = new SceneHandler();
        }
        return Instance;
    }
}
