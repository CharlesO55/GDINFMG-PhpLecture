using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// MAKE SURE THIS IS ATTACHED TO AN OBJECT
public class DatabaseManager : MonoBehaviour 
{
    private static DatabaseManager Instance;

    public static DatabaseManager GetInstance()
    {
        if (Instance == null)
        {
            Instance = new DatabaseManager();
        }
        return Instance;
    }


    [SerializeField] private string _username;
    public string Username
    {
        get { return _username; }
        set { _username = value; }
    }
    private int _score;
    public int Score
    {
        get { return _score; }
        set { _score = value; }
    }

    public bool IsLoggedIn()
    {
        return (this._username != null);
    }
    public void LogOut()
    {
        this._username = null;
    }

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }

        //ADD TO MAKE THIS PERSIST BETWEEN LOGIN AND GAME SCENE
        DontDestroyOnLoad(Instance);
    }


    private void OnDestroy()
    {
        this.LogOut();
        this._score = 0;
    }
}