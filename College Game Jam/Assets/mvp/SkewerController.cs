using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkewerController : MonoBehaviour
{
    private List<GameObject> skeweredItems;
    
    void Start()
    {
        skeweredItems = new List<GameObject>();
    }

    void Update()
    {
        foreach (GameObject g in skeweredItems)
        {
            g.transform.position += new Vector3(0, -1, 0);

        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log(other.collider.tag);
        if (other.collider.CompareTag("Fruit"))
        {
            GameObject fruit = other.gameObject;
            SkewerFruit(fruit);

        }
    }

    void SkewerFruit(GameObject fruit)
    {
        skeweredItems.Add(fruit);
        fruit.transform.parent = this.transform;
        Vector3 pos = fruit.transform.position;
        fruit.GetComponent<Collider2D>().enabled = false;
        fruit.GetComponent<FoodController>().skewered = true;
        fruit.transform.position = new Vector3(this.transform.position.x, pos.y, pos.z);
        fruit.transform.rotation = Quaternion.identity;
    }
    
    
}
