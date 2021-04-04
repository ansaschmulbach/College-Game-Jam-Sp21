using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToppingsUIController : MonoBehaviour
{

    #region Toppings Inspector Variables

    [SerializeField] private List<GameObject> marshmallows;
    [SerializeField] private List<GameObject> sprinkles;
    [SerializeField] private Vector3 spawnPos = new Vector3(-0.51f, 0.08f, -2);
    
    #endregion

    #region Private Variables

    private List<GameObject> currentFruit;
    private GameObject skewer;

    #endregion
    
    void Awake()
    {
        skewer = GameObject.FindGameObjectWithTag("Skewer");
        currentFruit = skewer.GetComponent<SkewerController>().skeweredItems;
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

    #endregion

}
