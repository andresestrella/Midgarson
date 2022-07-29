using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.Networking;
using System.Text.RegularExpressions;

public class GameStateController : MonoBehaviour
{
    private string url = "http://localhost:8082/api/gameState/";
    GameObject player;
    public GameState currentState;
    Enemy[] enemies;
    string gameStateJson = "";
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
            //id = 1;
        }
        
        currentState = new GameState(1, 1, "easy", playerLife.currentHealth, playerLife.currentShield, 150,
            "gun", player.transform.position.x, player.transform.position.y, playerLife.sceneController.scorePlay
            , enemies,playerLife.playerStatusUI.timePlay,
            player.GetComponent<PlayerMovement>().item1,
            player.GetComponent<PlayerMovement>().item2,
            player.GetComponent<PlayerMovement>().item3,
            player.GetComponent<PlayerMovement>().item4
            );
        string s = JsonUtility.ToJson(currentState, true);
        findAllEnemies();
        if (loaded)
        {
            //currentState.id = id;
        }
        UnityWebRequest server = UnityWebRequest.Put(url + "save", gameStateJson);
        server.SetRequestHeader("Content-Type", "application/json");
        yield return server.SendWebRequest();
        Debug.Log("Received: " + server.downloadHandler.text);


    }


    public IEnumerator LoadGame()
    {
        UnityWebRequest server = UnityWebRequest.Get(url + "load/1");
        server.SetRequestHeader("Content-Type", "application/json");
        yield return server.SendWebRequest();
        Debug.Log("Received: " + server.downloadHandler.text);
        loaded = true;
        currentState = JsonUtility.FromJson<GameState>(server.downloadHandler.text);
        addEnemiesToState(server.downloadHandler.text);
        loadAllEnemies();
        Debug.Log(player.transform.position);
        player.transform.position = new Vector3(currentState.currPosX, currentState.currPosY, 0);
        Debug.Log(player.transform.position);
        playerLife.setLoadedStatus(currentState.playerHealth, currentState.playerShield, currentState.score, currentState.time);
        extractItems(server.downloadHandler.text);
        //Initialize items
        player.GetComponent<PlayerMovement>().item1 = currentState.item1;
        player.GetComponent<PlayerMovement>().item2 = currentState.item2;
        player.GetComponent<PlayerMovement>().item3 = currentState.item3;
        player.GetComponent<PlayerMovement>().item4 = currentState.item4;
    }


    private void findAllEnemies()
    {

        var objsInScene = FindObjectsOfType<Enemy>();
        int openBracketsIndex, closeBracketsIndex;
        string mappedEnemies = "[ ";
        int ind = 0;
        gameStateJson = JsonUtility.ToJson(currentState)
            .Insert(JsonUtility.ToJson(currentState).Length-1,
            ",\"item1\":"+JsonUtility.ToJson( currentState.item1)+
            ",\"item2\":" + JsonUtility.ToJson(currentState.item2)+
            ",\"item3\":" + JsonUtility.ToJson(currentState.item3)+
            ",\"item4\":" + JsonUtility.ToJson(currentState.item4)
            );
        openBracketsIndex = gameStateJson.IndexOf("[");
        closeBracketsIndex = gameStateJson.IndexOf("]");
        
        foreach (Enemy aux in objsInScene)
        {
            Enemy enemy = aux.GetComponent<Enemy>();
            enemy.currPosX = enemy.transform.position.x;
            enemy.currPosY = enemy.transform.position.y;

            mappedEnemies += JsonUtility.ToJson(enemy);
            ind++;
            mappedEnemies += ind >= objsInScene.Length ? " " : ",";

        }
        currentState.enemies = (Enemy[])objsInScene;

        gameStateJson = gameStateJson.Remove(openBracketsIndex, closeBracketsIndex - openBracketsIndex).Insert(openBracketsIndex, mappedEnemies);
        //return new List<Enemy>(objsInScene);
    }

    private void extractItems(string obj)
    {
        int closeBrackets = obj.IndexOf("]"),ind = 0;
        obj = obj.Substring(closeBrackets);
        Match match = Regex.Match(obj, "({(.)[^}]+)}");
        string item;

        while (match.Success)
        {
            item = match.Value;
            Item item1 = JsonUtility.FromJson<Item>(item);
            switch (ind) {
                case 0: currentState.item1 = item1;
                    break;
                case 1: currentState.item2 = item1;
                    break;
                case 2: currentState.item3 = item1;
                    break;
                default: currentState.item4 = item1;
                    break;
            }
            
            ind++;
            match = match.NextMatch();

        }
    }

    private void addEnemiesToState(string obj)
    {
        string enemy = "";
        Enemy[] enemies = new Enemy[FindObjectsOfType<Enemy>().Length];
        int openBracketsIndex, closeBracketsIndex;
        openBracketsIndex = obj.IndexOf("[");
        closeBracketsIndex = obj.IndexOf("]");
        obj = obj.Substring(openBracketsIndex, (closeBracketsIndex + 1) - openBracketsIndex);
        openBracketsIndex = obj.IndexOf("[");
        closeBracketsIndex = obj.IndexOf("]");
        int ind = 0;
        Match match = Regex.Match(obj, "({(.)[^}]+)}");
        
        while (match.Success)
        {
            enemy = match.Value;
            EnemyDTO objTransfer = JsonUtility.FromJson<EnemyDTO>(enemy);
            Enemy enemyTransfer = new Enemy();
            if (!enemyTransfer.isDead)
            {
                enemyTransfer.id = objTransfer.id;
                enemyTransfer.isDead = objTransfer.isDead;
                enemyTransfer.life = objTransfer.life;
                enemyTransfer.name = objTransfer.name;
                enemyTransfer.direction = objTransfer.direction;
                enemyTransfer.damage = objTransfer.damage;
                enemyTransfer.currPosX = objTransfer.currPosX;
                enemyTransfer.currPosY = objTransfer.currPosY;
                enemies[ind] = enemyTransfer;
                ind++;
            }
            
            match = match.NextMatch();
            
        }
        //enemy = Regex.Match(obj, "({(.)[^}]+)}").Value;
        //for (int i = 1; i < obj.Length; ind++)
        //{
            //int indexOfComma = obj.IndexOf("},");
            //enemy += indexOfComma == -1 ? obj.Substring(i, closeBracketsIndex - i) : obj.Substring(i, indexOfComma + 1 - i);
            ////obj = obj.Remove(indexOfComma, 1);
            //i = indexOfComma == -1 ? obj.Length + 1 : indexOfComma + 1;
            //EnemyDTO objTransfer = JsonUtility.FromJson<EnemyDTO>(enemy);
            //Enemy enemyTransfer = new Enemy();
            //enemyTransfer.id = objTransfer.id;
            //enemyTransfer.isDead = objTransfer.isDead;
            //enemyTransfer.life = objTransfer.life;
            //enemyTransfer.name = objTransfer.name;
            //enemyTransfer.direction = objTransfer.direction;
            //enemyTransfer.damage = objTransfer.damage;
            //enemyTransfer.currPosX = objTransfer.currPosX;
            //enemyTransfer.currPosY = objTransfer.currPosY;
            //enemies[ind] = enemyTransfer;

            //enemy = "";
        //}
        currentState.enemies = enemies;
    }



    private void loadAllEnemies()
    {
        var objsInScene = FindObjectsOfType<Enemy>();
        //var objsInScene = FindObjectsOfTypeAll(typeof(Enemy));
        int ind = 0;
        foreach (Enemy aux in objsInScene)
        {
            Enemy enemy = aux.GetComponent<Enemy>();
            
                enemy.transform.position = new Vector3(currentState.enemies[ind].currPosX, currentState.enemies[ind].currPosY);
                enemy.life = currentState.enemies[ind].life;
                enemy.isDead = currentState.enemies[ind].isDead;
                ind++;
        }
    }






}
