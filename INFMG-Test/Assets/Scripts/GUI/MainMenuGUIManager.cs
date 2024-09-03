using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

/* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * 
 *                         DO NOT EDIT THIS SCRIPT                         *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */

public class MainMenuGUIManager : MonoBehaviour {

    /* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * 
     *                               PROPERTIES                                *
     * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */

    private TextField _username;
    public String Username
    {
        get { return _username.value; }
    }
    private TextField _password;
    public string Password
    {
        get { return _password.value; }
    }

    public static MainMenuGUIManager Instance;
    private VisualElement _root;
    private Button _login;
    private Button _register;

    /* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * 
     *                             GENERAL METHODS                             *
     * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */


    /* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * 
     *                            LIFECYCLE METHODS                            *
     * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */

    private void Awake() {
        if(Instance == null)
            Instance = this;
        else
            Destroy(this.gameObject);
    }

    private void Start() {
        this._root = this.GetComponent<UIDocument>().rootVisualElement;
        this._login = this._root.Q<Button>("Login");
        this._register = this._root.Q<Button>("Register");

        this._username = this._root.Q<TextField>("Username");
        this._password = this._root.Q<TextField>("Password");

        this._login.RegisterCallback<ClickEvent>(OnLoginClick);
        this._register.RegisterCallback<ClickEvent>(OnRegisterClick);
    }

    private void OnLoginClick(EventBase evt) {
        Debug.Log("LOGIN");
        Login.GetInstance().StartLoginUser();
    }

    private void OnRegisterClick(EventBase evt) {
        Debug.Log("REGISTER");
        SceneHandler.GetInstance().OpenRegister();
    }

    /* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * 
     *            HELPER METHODS THAT YOU DON'T NEED TO WORRY ABOUT            *
     * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
    public static MainMenuGUIManager GetInstance() {
        if(Instance == null) {
            Instance = new MainMenuGUIManager();
        }
        return Instance;
    }
}
