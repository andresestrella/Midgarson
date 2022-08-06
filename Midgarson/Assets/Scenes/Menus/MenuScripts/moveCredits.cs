using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveCredits : MonoBehaviour
{
    Vector2 deltaPos = new Vector2();
    float speed = 0.7f;
    public float MAX_Y, MIN_Y;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up * Time.deltaTime * speed);

        gameObject.transform.position = new Vector2(
            gameObject.transform.position.x,
            Mathf.Clamp(gameObject.transform.position.y, MIN_Y, MAX_Y)
        );
    }
}
