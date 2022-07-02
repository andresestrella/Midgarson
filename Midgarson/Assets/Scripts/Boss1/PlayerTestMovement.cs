using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTestMovement : MonoBehaviour
{
    Vector3 _deltaPos = new Vector3();
    Vector3 _movementSpeed = new Vector3(10,10);
    const float MIN_X = -8f, MAX_X = 8f, MIN_Y = -4f, MAX_Y = 4f;

    public float forceValue = 5;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _deltaPos.x = (Input.GetAxis("Horizontal") * _movementSpeed.x);
        _deltaPos.y = Input.GetAxis("Vertical") * _movementSpeed.y;
        _deltaPos *= Time.deltaTime;

        gameObject.transform.Translate(_deltaPos);

        gameObject.transform.position = new Vector3(
            Mathf.Clamp(gameObject.transform.position.x, MIN_X, MAX_X),
            Mathf.Clamp(gameObject.transform.position.y, MIN_Y, MAX_Y),
            gameObject.transform.position.z
        );
    }

    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.tag == "Player"){
            print("hit!");
        }
    }
}
