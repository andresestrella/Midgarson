using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public static int direction = 0;

    Vector3 _deltaPos = new Vector3();
    Vector3 _movementSpeed = new Vector3(5,0);
    const float MIN_X = 0.88f, MAX_X = 19.2f;

    void Update() {
        transform.Translate(Vector3.right * 4 * Time.deltaTime * direction);

        gameObject.transform.position = new Vector3(
            Mathf.Clamp(gameObject.transform.position.x, MIN_X, MAX_X),
            gameObject.transform.position.y,
            gameObject.transform.position.z
        );
    }
}
