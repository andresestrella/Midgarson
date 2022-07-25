using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeftBoat : MonoBehaviour
{
    private float force = 0.01f;

    void Update()
    {
        transform.position += Vector3.right * force;
    }
}
