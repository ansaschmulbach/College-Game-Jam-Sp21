using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class SkewerController : MonoBehaviour
{

    #region Inspector Variables

    [SerializeField] [Tooltip("The max number of skewered items to be displayed on the screen.")]
    private int maxSkeweredDisplay;

    [SerializeField] [Tooltip("The max number of skewered items before loading next scene.")]
    public int maxSkewered;

    [SerializeField] [Tooltip("The y value to display the top skewered item at.")]
    private float topItemY;
    
    #endregion

    #region Private Variables

    [Header("Do not edit")]
    public List<GameObject> skeweredItems;

    #endregion

    #region Unity Methods

    void Start()
    {
        skeweredItems = new List<GameObject>();
        GetComponent<SpriteRenderer>().sprite = GameManager.Instance.gameState.skewerSprite;
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

    #endregion

    #region Skewer Methods

    void SkewerFruit(GameObject fruit)
    {
        skeweredItems.Add(fruit);
        fruit.transform.parent = this.transform;
        Vector3 pos = fruit.transform.position;
        fruit.GetComponent<Collider2D>().enabled = false;
        fruit.GetComponent<FoodController>().skewered = true;
        fruit.transform.position = new Vector3(this.transform.position.x, pos.y, transform.position.z - skeweredItems.Count);
        UpdateScreen();
    }

    void UpdateScreen()
    {
        int i = maxSkeweredDisplay - 1;
        int j = skeweredItems.Count - 1;
        if (i >= j)
        {
            GameObject go = skeweredItems[j];
            FoodController fruit = go.GetComponent<FoodController>();
            fruit.UpdateMaxY(topItemY - go.GetComponent<BoxCollider2D>().size.y * (i-j));
            Debug.Log(go.GetComponent<BoxCollider2D>().size.y);
        }
        else
        {
            foreach (GameObject go in skeweredItems)
            {
                FoodController fruit = go.GetComponent<FoodController>();
                fruit.UpdateMaxY(fruit.maxYCoordinate - go.GetComponent<BoxCollider2D>().size.y);
            }

            GameObject go2 = skeweredItems[j];
            FoodController fruit2 = go2.GetComponent<FoodController>();
            fruit2.UpdateMaxY(topItemY);
        }
    }

    #endregion

    public void SaveAsPrefab()
    {
        GameObject fullSkewerPrefab = PrefabUtility.SaveAsPrefabAsset(this.gameObject, "Assets/FullSkewer.prefab");
        fullSkewerPrefab.GetComponent<FollowMouse>().enabled = false;
    }
    
}
