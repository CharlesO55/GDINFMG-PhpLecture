using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*
 * [1] : Make sure DatabaseManager is attached to a gameobject inside MainMenuScene
 * [2] : Add DontDestroyOnLoad() for DatabaseManager's Awake()
 * [3] : Attach this SaveData script a gameobject inside GameScene
 * [4] : Call SaveData.GetInstance().StartAddScore() on Ghost detect trigger
*/
public class SaveData : MonoBehaviour
{
    private static SaveData Instance;
    public static SaveData GetInstance()
    {
        if(Instance == null)
            Instance = new SaveData();

        return Instance;
    }

    private void Awake()
    {
        if(Instance != null)
            Destroy(this.gameObject);
        else
            Instance = this;
    }

    public void StartAddScore()
    {
        if (!DatabaseManager.GetInstance().IsLoggedIn())
        {
            Debug.LogError("[AddScore] Login User first from Main Menu Scene to get proper score value");
            return;
        }

        //MOVE THIS OUT WHEN WANT SO SEPARATE FUNCTIONALITY TO PURELY SAVING DATA ONLY
        DatabaseManager.GetInstance().Score++;

        StartCoroutine(UpdateScore());
    }

    private IEnumerator UpdateScore()
    {
        WWWForm form = new();
        form.AddField("Username", DatabaseManager.GetInstance().Username);
        form.AddField("NewScore", DatabaseManager.GetInstance().Score);

        WWW handler = new WWW("http://localhost/sqlconnect/savedata.php", form);
        yield return handler;

        string lastMsg = handler.text.Split("\t")[^1];
        if (lastMsg == "[SUCCESS]")
            Debug.Log($"Added Score {lastMsg}");
        else
            Debug.LogError($"Failed to Add Score {lastMsg}");
    }
}
