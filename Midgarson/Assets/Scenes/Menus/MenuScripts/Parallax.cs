using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    float scrollingSpeed = 0.2f, currentTempSpeed;
    Vector2 currentPosition = new Vector2();
    MeshRenderer renderer;

    private void Awake() {
        renderer = GetComponent<MeshRenderer>();
    }

    private void Update() {
        currentTempSpeed = scrollingSpeed = (10/gameObject.transform.position.z);
        currentPosition.x = currentPosition.x + scrollingSpeed *  Time.deltaTime;

        renderer.material.mainTextureOffset = currentPosition;
    }
}
