using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Upload : MonoBehaviour
{
    private static Upload Instance;
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private SpriteRenderer _targetRenderer;


    public static Upload GetInstance()
    {
        if(Instance == null)
            Instance = new Upload();
        return Instance;
    }

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

    private void Start()
    {
        if(DatabaseManager.GetInstance().Username == null)
        {
            SceneHandler.GetInstance().OpenLogin();
        }
    }

    public void StartUplaod()
    {
        this.StartCoroutine(this.UploadImage());
    }

    private IEnumerator UploadImage()
    {
        WWWForm form = new WWWForm();

        Texture2D texture = CopyTexture(_spriteRenderer.sprite.texture); ;
        byte[] imageBytes = texture.EncodeToPNG();
        

        form.AddField("username", DatabaseManager.GetInstance().Username);
        form.AddBinaryData("image",
            imageBytes, 
            DatabaseManager.GetInstance().Username + ".png", 
            "image/png");



        using (UnityWebRequest handler = UnityWebRequest.Post("http://localhost/sqlconnect/upload.php", form))
        {
            yield return handler.SendWebRequest();


            string[] result = handler.downloadHandler.text.Split("\t");
            if (handler.error == null)
            {
                Debug.Log("Uploaded image");

                Debug.Log($"Retrieved link {handler.downloadHandler.text}");
                //TextureManager.GetInstance().StartSetTexture(this._targetRenderer, handler.downloadHandler.text);
            }
            else
                Debug.LogError("Failed to login [ERROR]: " + handler.error);
        }
        yield return null;
    }



    Texture2D CopyTexture(Texture2D source)
    {

        RenderTexture renderTexture = RenderTexture.GetTemporary(
            source.width, source.height, 0, RenderTextureFormat.Default, RenderTextureReadWrite.Linear);

        Graphics.Blit(source, renderTexture);

        RenderTexture previous = RenderTexture.active;
        RenderTexture.active = renderTexture;

        Texture2D readableTexture = new Texture2D(source.width, source.height);
        readableTexture.ReadPixels(new Rect(0, 0, renderTexture.width, renderTexture.height), 0, 0);
        readableTexture.Apply();

        RenderTexture.active = previous;
        RenderTexture.ReleaseTemporary(renderTexture);
        return readableTexture;
    }
}