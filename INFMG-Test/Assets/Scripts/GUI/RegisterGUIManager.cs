using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

/* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * 
 *                         DO NOT EDIT THIS SCRIPT                         *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */

public class RegisterGUIManager : MonoBehaviour {

    /* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * 
     *                               PROPERTIES                                *
     * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */

    public static RegisterGUIManager Instance;
    private VisualElement _root;
    private TextField _username;
    public string Username {
        get { return this._username.value; }
    }

    private TextField _password;
    public string Password {
        get { return this._password.value; }
    }

    private Button _confirm;
    private Button _cancel;

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
        this._username = this._root.Q<TextField>("Username");
        this._password = this._root.Q<TextField>("Password");
        this._confirm = this._root.Q<Button>("Confirm");
        this._cancel = this._root.Q<Button>("Cancel");

        this._confirm.RegisterCallback<ClickEvent>(OnConfirmClick);
        this._cancel.RegisterCallback<ClickEvent>(OnCancelClick);
    }

    private void OnConfirmClick(EventBase evt) {
        Register.GetInstance().StartRegisterUser();
    }

    private void OnCancelClick(EventBase evt) {
        Debug.Log("CANCEL");
        SceneHandler.GetInstance().OpenLogin();
    }

    /* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * 
     *            HELPER METHODS THAT YOU DON'T NEED TO WORRY ABOUT            *
     * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
    public static RegisterGUIManager GetInstance() {
        if(Instance == null) {
            Instance = new RegisterGUIManager();
        }
        return Instance;
    }
}
