using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class TextureManager : MonoBehaviour
{
    private static TextureManager instance;
    public static TextureManager GetInstance()
    {
        if (instance == null)
        {
            instance = new TextureManager();
        }
        return instance;
    }

    private void Awake()
    {
        if(instance != null)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
        }
    }
    public void StartSetTexture(SpriteRenderer targetRenderer, string url)
    {
        StartCoroutine(SetTexture(targetRenderer, url));
    }

    private IEnumerator SetTexture(SpriteRenderer targetRenderer, string url)
    {
        UnityWebRequest request = UnityWebRequestTexture.GetTexture(url);
        yield return request.SendWebRequest();

        if(request.result == UnityWebRequest.Result.ConnectionError ||
            request.result == UnityWebRequest.Result.ProtocolError) 
        {
            Debug.LogError("Web request failed");
        }
        else
        {
            Texture2D texture = ((DownloadHandlerTexture)request.downloadHandler).texture;
            Sprite sprite = Sprite.Create(texture,
                new Rect(0f,
                        0f,
                        texture.width,
                        texture.height),
                new Vector2(0.5f, 0.5f)
            );
            targetRenderer.sprite = sprite;
        }
    }
}
