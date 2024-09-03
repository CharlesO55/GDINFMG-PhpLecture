using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Register : MonoBehaviour {
    public static Register Instance;

    public void StartRegisterUser() {
        if (this.VerifyInformation())
        {
            this.StartCoroutine(RegisterUser());
        }
        else
        {
            Debug.LogError("Verify information failed");
        }
    }

    private IEnumerator RegisterUser() {
        WWWForm form = new WWWForm();
        form.AddField("username", RegisterGUIManager.GetInstance().Username);
        form.AddField("password", RegisterGUIManager.GetInstance().Password);


        WWW handler = new WWW("http://localhost/sqlconnect/register.php", form);
        yield return handler;

        string[] results = handler.text.Split("\t");

        if (results[0] == "0")
            Debug.Log("User successfuly added");
        else
            Debug.LogError("Failed to register [ERROR]: " + handler.text);
    }

    private bool VerifyInformation() {
        string username = RegisterGUIManager.GetInstance().Username;
        string password = RegisterGUIManager.GetInstance().Password;

        if(username.Length >= 5 && username.Length <= 20 && password.Length >= 5)
        {
            return true;
        }
        else
        {
            Debug.LogWarning("Username and Password length no");
            return false;
        }
    }

    private void Awake() {
        if(Instance == null)
            Instance = this;
        else
            Destroy(this.gameObject);
    }

    public static Register GetInstance() {
        if(Instance == null) {
            Instance = new Register();
        }
        return Instance;
    }
}
