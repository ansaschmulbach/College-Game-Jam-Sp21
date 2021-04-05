using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class CompletedSkewerController : MonoBehaviour
{

    void Start()
    {
        GameObject toppingsHolder = GameObject.FindWithTag("Toppings");
        toppingsHolder.transform.parent = this.transform;
    }
    public void SaveAsPrefab()
    {
        GameObject fullSkewerPrefab = PrefabUtility.SaveAsPrefabAsset(this.gameObject, "Assets/FullSkewer.prefab");
        fullSkewerPrefab.GetComponent<CompletedSkewerController>().enabled = false;
    }
    
}
