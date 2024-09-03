using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class ProfileGUIManager : MonoBehaviour
{
    private static ProfileGUIManager Instance;

    private VisualElement _root;
    private Button _upload;
    private Button _back;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(this.gameObject);
    }
    public static ProfileGUIManager GetInstance()
    {
        if (Instance == null)
        {
            Instance = new ProfileGUIManager();
        }
        return Instance;
    }


    private void Start()
    {
        this._root = this.GetComponent<UIDocument>().rootVisualElement;
        this._upload = this._root.Q<Button>("Upload");
        this._back = this._root.Q<Button>("Back");

        this._upload.RegisterCallback<ClickEvent>(OnUploadClick);
        this._back.RegisterCallback<ClickEvent>(OnBackClick);
    }

    private void OnUploadClick(ClickEvent evt)
    {
        Debug.Log("Upload start");
        Upload.GetInstance().StartUplaod();
    }
    private void OnBackClick(ClickEvent evt)
    {
        Debug.Log("Back click");
        SceneHandler.GetInstance().OpenLogin();
    }
}