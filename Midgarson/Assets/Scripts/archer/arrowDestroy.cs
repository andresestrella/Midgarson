using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrowDestroy : MonoBehaviour
{
    // Start is called before the first frame update
    float time =0;
    void Start()
    {
     
    }

    // Update is called once per frame
    void Update()
    {


    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
