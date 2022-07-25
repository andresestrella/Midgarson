using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldBehaviour : MonoBehaviour
{
    GameObject centerObject;
    Vector3 _currentPosition = new Vector3(), currentSpeed = new Vector3(7, 7), angle;
    float scalarAcceleration = 0f, shootingTime;
    public float distance = 0;
    public Vector3 startRotation;
    private int speed = 200;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.forward, speed * Time.deltaTime);
        _currentPosition.x = centerObject.transform.position.x + distance;
        _currentPosition.y = centerObject.transform.position.y;
        gameObject.transform.position = _currentPosition;

        /*angle = currentSpeed * (Time.time - shootingTime) / currentDistance;

        _currentPosition.x = centerObject.transform.position.x + currentDistance * Mathf.Cos(angle.x);
        _currentPosition.y = centerObject.transform.position.y + currentDistance * Mathf.Sin(angle.y);
        gameObject.transform.position = _currentPosition;

        currentSpeed.x += scalarAcceleration * Time.deltaTime;
        currentSpeed.y += scalarAcceleration * Time.deltaTime;*/
    }

    public void Shoot(GameObject center)
    {
        centerObject = center;
    }
}
