using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndUIController : MonoBehaviour
{

    [SerializeField] private List<Image> flowers;
    private SkewerController skewer;

    void Start()
    {
        skewer = GameObject.FindWithTag("Skewer").GetComponent<SkewerController>();
        LoadSkewerObject(SaveSystem.LoadSkewer(), skewer);
        
        
        Debug.Log(Score());
        // for (int i = 0; i < Score(); i++)
        // {
        //     flowers[i].enabled = true;
        // }
        //
        // for (int i = Score(); i < flowers.Count; i++)
        // {
        //     flowers[i].enabled = false;
        // }
    }

    public static void LoadSkewerObject(SkewerSaveData saveData, SkewerController skewer)
    {
        for (int i = 0; i < saveData.dangos.Length; i++)
        {
            SkewerSaveData.DangoSaveData dango = saveData.dangos[i];
            GameObject dangoGO = FoodController.LoadDango(dango, skewer);
            if (dango.marshmallows.enabled)
            {
                Instantiate(ToppingsUIController._marshmallows[i], 
                    ToppingsUIController._spawnPos + dangoGO.transform.position, 
                            Quaternion.identity, dangoGO.transform); 
            }

            if (dango.sprinkles.enabled)
            {
                Instantiate(ToppingsUIController._sprinkles[i], 
                    ToppingsUIController._spawnPos + dangoGO.transform.position, 
                            Quaternion.identity, dangoGO.transform);

            }

            if (dango.condensed)
            {
                dangoGO.GetComponent<SpriteRenderer>().sprite =
                    dangoGO.GetComponent<FoodController>().condensedMilkSprite;
            }

        }
    }
    
    int Score()
    {
        List<GameObject> fruit = skewer.skeweredItems;
        List<GameObject> recipe = GameManager.Instance.gameState.recipe;
//        Debug.Log(recipe);
        bool containsAll = true;
        int stars = 3;
        
        foreach (GameObject go in recipe)
        {
            if (!hasName(fruit, go.name))
            {
                containsAll = false;
                //Debug.Log(go.name);
            }
        }

        if (!containsAll)
        {
            stars -= 1;
        }
        else
        {
            Debug.Log("contains all");
        }

        bool hasExtra = false;
        foreach (GameObject go in fruit)
        {
            if (!hasName(recipe, go.name))
            {
                hasExtra = true;
            }
        }

        if (hasExtra)
        {
            stars -= 1;
        }
        else
        {
            //Debug.Log("has no extra");
        }

        bool isPerfect = fruit.Count == recipe.Count;
        for (int i = 0; i < Math.Min(fruit.Count, recipe.Count); i++)
        {

            if (!(fruit[i].name).Equals(recipe[i].name) && !(fruit[i].name + "(Clone)").Equals(recipe[i].name))
            {
                isPerfect = false;
//                Debug.Log(fruit[i].name + ", " + recipe[i].name);
            }
            
            // if (!fruit[i].Equals(recipe[i]))
            // {
            //     isPerfect = false;
            // }
        }

        if (!isPerfect)
        {
            stars -= 1;
        }
        else
        {
//            Debug.Log("is perfect");
        }
        
        return stars;

    }

    public void BackToGame()
    {
        GameManager.Instance.CustomerEnter();
    }
    
    bool hasName(List<GameObject> lst, string name)
    {
        foreach (GameObject go in lst)
        {
            if ((go.name).Equals(name) || (go.name + "(Clone)").Equals(name))
            {
                return true;
            }
        }

        return false;
    }
    
    

}
