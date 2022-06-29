using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool stopFlag = false;
    public GameObject birdEnemy;
    void Awake(){
        
    }
    void Start()
    {
        StartCoroutine(SpawnBirds());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnBirds(){
        while (true){
            
            if (stopFlag == true){
                yield break;
            }else{
                Instantiate(birdEnemy);
                yield return new WaitForSeconds(Random.Range(10,15));
            }
            
        }
    }


}
