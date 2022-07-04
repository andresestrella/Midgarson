using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Networking;

//Sería buena idea cambiar el nombre para identificar que es todo lo que tenga que ver con el servicio web
public class LogIn : MonoBehaviour
{
    UnityWebRequest www;

    public TMP_InputField userName;
    public TMP_InputField password;


    const string API_URI = "http://localhost:8080/api/";

    public void LoginButton()
    {
        Debug.Log(API_URI);
        StartCoroutine(sendUserRequest(userName.text, password.text, "user/validateUser"));

    }
    public void RegisterButton()
    {
        StartCoroutine(sendUserRequest(userName.text, password.text, "user/createUser"));
    }


    IEnumerator sendUserRequest(string username, string password,string endpoint)
    {
        User user = new User();
        user.name = username;
        user.password = password;

        www = UnityWebRequest.Put(API_URI + endpoint, JsonUtility.ToJson(user));
        www.SetRequestHeader("Content-Type", "application/json");
        yield return www.SendWebRequest();
        Debug.Log(www.downloadHandler.text);

    }

    public IEnumerator getUser(string username)
    {
        www = UnityWebRequest.Get(API_URI + "user?user=" + username);
        www.SetRequestHeader("Content-Type", "application/json");
        www.SendWebRequest();
        yield return JsonUtility.FromJson<User>(www.downloadHandler.text);
       
    }
    public IEnumerator updateScore(User user)
    {
        www = UnityWebRequest.Put(API_URI + "user/updateScore", JsonUtility.ToJson(user));
        www.SetRequestHeader("Content-Type", "application/json");
        yield return www.SendWebRequest();
        Debug.Log(www.downloadHandler.text);

    }
    public IEnumerator getScoreBoard(User user)
    {
        www = UnityWebRequest.Get(API_URI + "user/scoreBoard");
        www.SetRequestHeader("Content-Type", "application/json");
        www.SendWebRequest();
        yield return www.downloadHandler.text;
    }

}
