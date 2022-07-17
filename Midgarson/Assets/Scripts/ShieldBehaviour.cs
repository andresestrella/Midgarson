using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldBehaviour : MonoBehaviour
{
    GameObject centerObject;
    Vector3 _currentPosition = new Vector3(), currentSpeed = new Vector3(10, 10), angle;
    float currentDistance, scalarAcceleration = 0f, shootingTime;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        angle = currentSpeed * (Time.time - shootingTime) / currentDistance;

        _currentPosition.x = centerObject.transform.position.x + currentDistance * Mathf.Cos(angle.x);
        _currentPosition.y = centerObject.transform.position.y + currentDistance * Mathf.Sin(angle.y);
        gameObject.transform.position = _currentPosition;

        currentSpeed.x += scalarAcceleration * Time.deltaTime;
        currentSpeed.y += scalarAcceleration * Time.deltaTime;
    }

    public void Shoot(GameObject center, float distance)
    {
        centerObject = center;
        currentDistance = distance;
        shootingTime = Time.time;
    }
}
