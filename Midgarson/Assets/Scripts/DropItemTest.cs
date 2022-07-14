using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropItemTest : MonoBehaviour
{
    public GameObject Item;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            Destroy(gameObject);
            DropItem();
        }
    }

    public void DropItem()
    {
        Vector3 position = transform.position;
        Instantiate(Item, position, Quaternion.identity);
    }
}
