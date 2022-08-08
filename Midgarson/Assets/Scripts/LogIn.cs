using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Networking;
using System.Threading;
using UnityEngine.SceneManagement;

//Sería buena idea cambiar el nombre para identificar que es todo lo que tenga que ver con el servicio web
public class LogIn : MonoBehaviour
{
    UnityWebRequest www;

    public TMP_InputField userName;
    public TMP_InputField password;
    private GameStateController controller;

    const string API_URI = "http://localhost:8082/api/";

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

        user = JsonUtility.FromJson<User>(www.downloadHandler.text);
        PlayerPrefs.SetInt("id", (int) user.id);
        PlayerPrefs.SetString("username", user.name);
        PlayerPrefs.SetString("password", password);
        PlayerPrefs.SetInt("puntaje", (int) user.puntaje);
        PlayerPrefs.Save();
        controller = GetComponent<GameStateController>();
        yield return StartCoroutine(controller.LoadGame());
        PlayerPrefs.SetInt("L1", controller.currentState.scoreL1);
        PlayerPrefs.SetInt("L2", controller.currentState.scoreL2);
        PlayerPrefs.SetInt("L3", controller.currentState.scoreL3);
        PlayerPrefs.SetInt("L4", controller.currentState.scoreL4);
        PlayerPrefs.SetInt("L5", controller.currentState.scoreL5);
        PlayerPrefs.SetInt("L6", controller.currentState.scoreL6);
        PlayerPrefs.Save();
        if (endpoint.Equals("user/createUser"))
        {
            GameObject.Find("Canvas").GetComponent<Canvas>().scaleFactor = 0;
            GameObject.Find("TimelineManager").GetComponent<TimelineController>().Play();
            yield return new WaitForSeconds(21);

            //Thread.Sleep(20000);
        }
        SceneManager.LoadScene("SelectLevel");
    }

    public User getUser(string username)
    {
        www = UnityWebRequest.Get(API_URI + "user?user=" + username);
        www.SetRequestHeader("Content-Type", "application/json");
        www.SendWebRequest();
        return JsonUtility.FromJson<User>(www.downloadHandler.text);
       
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
