using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompletedSkewerController : MonoBehaviour
{

    void Start()
    {
        GameObject toppingsHolder = GameObject.FindWithTag("Toppings");
        toppingsHolder.transform.parent = this.transform;
    }

    
}
