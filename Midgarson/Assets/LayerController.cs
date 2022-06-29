using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LayerController : MonoBehaviour
{
    

    float _scrollingSpeed = 0.1f, _currentTempSpeed;
    Vector2 _currentPosition = new Vector2();
    MeshRenderer _renderer;
    // Start is called before the first frame update

    private void Awake()
    {
        _renderer = GetComponent<MeshRenderer>();
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _currentTempSpeed = _scrollingSpeed * (20 / gameObject.transform.position.z);

        _currentPosition.x = _currentPosition.x + _currentTempSpeed * Time.deltaTime;

        _renderer.material.mainTextureOffset = _currentPosition;
    }
}
