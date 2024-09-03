using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackendTest : MonoBehaviour
{
    private IEnumerator Start()
    {
        string url = "http://localhost/sqlconnect/backendtest.php";
        WWW request = new WWW(url);
        yield return request;


        Debug.Log(request.text);
        string[] messages = request.text.Split("\t");
    }
}