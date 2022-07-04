using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class GameStateController : MonoBehaviour
{
    private string url = "http://localhost:8082/api/gameState/";
    GameObject player;
    public GameState currentState;
    bool loaded = false;
    public PlayerLife playerLife = new PlayerLife();
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        //test implementations
        if (Input.GetKey(KeyCode.LeftControl) && Input.GetKeyDown(KeyCode.S))
            StartCoroutine(saveGame());
        if (Input.GetKey(KeyCode.LeftControl) && Input.GetKeyDown(KeyCode.L))
            StartCoroutine(LoadGame());
    }

    public IEnumerator saveGame()
    {
        long? id = null;
        if (loaded)
        {
            id = currentState.id;
        }
         
        currentState = new GameState(1, 1, "easy", playerLife.currentHealth,playerLife.currentShield, 150,
            "gun", player.transform.position.x, player.transform.position.y,playerLife.sceneController.scorePlay);
        Debug.Log(JsonUtility.ToJson( currentState));
        
        if (loaded)
        {
            currentState.id = id;
        }
        UnityWebRequest server = UnityWebRequest.Put(url + "save", JsonUtility.ToJson(currentState));
        server.SetRequestHeader("Content-Type", "application/json");
        yield return server.SendWebRequest();
        Debug.Log("Received: " + server.downloadHandler.text);
        

    }

    public IEnumerator LoadGame()
    {
        UnityWebRequest server = UnityWebRequest.Get(url+"load/1");
        server.SetRequestHeader("Content-Type", "application/json");
        yield return server.SendWebRequest();
        Debug.Log("Received: " + server.downloadHandler.text);
        loaded = true;
        currentState = JsonUtility.FromJson<GameState>(server.downloadHandler.text);
        Debug.Log(player.transform.position);
        player.transform.position = new Vector3(currentState.currPosX, currentState.currPosY, 0);
        Debug.Log(player.transform.position);
        playerLife.setLoadedHealth(currentState.playerHealth, currentState.playerShield,currentState.score);
    }







}
