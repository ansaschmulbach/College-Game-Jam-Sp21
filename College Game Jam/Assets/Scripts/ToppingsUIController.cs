using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToppingsUIController : MonoBehaviour
{

    #region Toppings Inspector Variables

    [SerializeField] private List<GameObject> marshmallows;
    [SerializeField] private List<GameObject> sprinkles;
    [SerializeField] private Vector3 spawnPos = new Vector3(-0.51f, 0.08f, -2);
    
    public static List<GameObject> _marshmallows;
    public static List<GameObject> _sprinkles;
    public static Vector3 _spawnPos;
    
    #endregion

    #region Private Variables

    private List<GameObject> currentFruit;
    private GameObject skewer;

    #endregion
    
    void Awake()
    {
        skewer = GameObject.FindGameObjectWithTag("Skewer");
        LoadSkewerObject(SaveSystem.LoadSkewer(), skewer.GetComponent<SkewerController>());
        currentFruit = skewer.GetComponent<SkewerController>().skeweredItems;
        
        _marshmallows = marshmallows;
        _sprinkles = sprinkles;
        _spawnPos = spawnPos;
        
        for (int i = 0; i < currentFruit.Count; i++)
        {
            GameObject fruit = currentFruit[i];
            GameObject marsh = Instantiate(marshmallows[i], spawnPos + fruit.transform.position, Quaternion.identity, fruit.transform);
            GameObject sprinkle = Instantiate(sprinkles[i], spawnPos + fruit.transform.position, Quaternion.identity, fruit.transform);
            FoodController fruitScript = fruit.GetComponent<FoodController>();
            marsh.GetComponent<SpriteRenderer>().enabled = false;
            sprinkle.GetComponent<SpriteRenderer>().enabled = false;
            fruitScript.marshmallows = marsh;
            fruitScript.sprinkles = sprinkle;
        }
        
        Debug.Log("Current count: " + skewer.GetComponent<SkewerController>().skeweredItems.Count);
        
    }
    
    public static void LoadSkewerObject(SkewerSaveData saveData, SkewerController skewer)
    {
        foreach (SkewerSaveData.DangoSaveData dango in saveData.dangos)
        {
            FoodController.LoadDango(dango, skewer);
        }
    }

    #region Button Methods

    public void ToggleMarshmallows()
    {
        foreach (GameObject fruit in currentFruit)
        {
            FoodController fc = fruit.GetComponent<FoodController>();
            fc.ToggleMarshmallows();
        }
    }

    public void ToggleSprinkles()
    {
        foreach (GameObject fruit in currentFruit)
        {
            FoodController fc = fruit.GetComponent<FoodController>();
            fc.ToggleSprinkles();
        }
    }

    public void ToggleCondensedMilk()
    {
        foreach (GameObject fruit in currentFruit)
        {
            FoodController fc = fruit.GetComponent<FoodController>();
            fc.ToggleCondensed();
        }
    }

    public void TransitionToEnd()
    {
        skewer.GetComponent<SkewerController>().skeweredItems = currentFruit;
        skewer.GetComponent<SkewerController>().SaveAsPrefab();
        GameManager.Instance.EndScene();
    }

    #endregion

}
