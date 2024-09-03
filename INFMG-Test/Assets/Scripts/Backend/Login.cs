using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Login : MonoBehaviour
{
    private static Login Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public void StartLoginUser()
    {
        if (VerifyInput())
        {
            this.StartCoroutine(LoginUser());
        }
        else
            Debug.LogError("Inputs are insufficient");
    }

    private bool VerifyInput()
    {
        if (MainMenuGUIManager.GetInstance().Password.Length > 0 &&
            MainMenuGUIManager.GetInstance().Username.Length > 0)
        {
            return true;
        }
        return false;
    }
    private IEnumerator LoginUser()
    {
        WWWForm form = new();
        form.AddField("username", MainMenuGUIManager.GetInstance().Username);
        form.AddField("password", MainMenuGUIManager.GetInstance().Password);


        using(UnityWebRequest handler = UnityWebRequest.Post("http://localhost/sqlconnect/login.php", form))
        {
            yield return handler.SendWebRequest();


            string[] result = handler.downloadHandler.text.Split("\t");
            if (result[0] == "0")
            {
                Debug.Log("User successfully logged in");
                DatabaseManager.GetInstance().Username = MainMenuGUIManager.GetInstance().Username;
                DatabaseManager.GetInstance().Score = int.Parse(result[1]);

                Debug.Log($"User: {DatabaseManager.GetInstance().Username} Score: {DatabaseManager.GetInstance().Score}");

                //SceneHandler.GetInstance().OpenGame();
                SceneHandler.GetInstance().OpenProfile();
            }
            else
                Debug.LogError("Failed to login [ERROR]: " + handler.error);
        }
        /*WWW handler = new WWW("http://localhost/sqlconnect/login.php", form);
        yield return handler;

        string[] result = handler.text.Split("\t");
        if (result[0] == "0")
        {
            Debug.Log("User successfully logged in");
            DatabaseManager.GetInstance().Username = MainMenuGUIManager.GetInstance().Username;
            DatabaseManager.GetInstance().Score = int.Parse(result[1]);
            
            Debug.Log($"User: {DatabaseManager.GetInstance().Username} Score: {DatabaseManager.GetInstance().Score}");

            SceneHandler.GetInstance().OpenGame();
        }
        else
            Debug.LogError("Failed to login [ERROR]: " + handler.text);*/
    }

    

    public static Login GetInstance()
    {
        if (Instance == null)
        {
            Instance = new Login();
        }
        return Instance;
    }

    
}
