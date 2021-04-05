using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class recipeAlgo : MonoBehaviour
{
    #region Inspector Variables

    [SerializeField] [Tooltip("how long the recipe is")] private int target = 6;
    [SerializeField] [Tooltip("how many random fruits there are")] private int random = 12;
    [SerializeField] [Tooltip("all fruit prototypes")] private List<GameObject> fruits;
    [SerializeField] [Tooltip("all dango prototypes")] private List<GameObject> dango;
    
    #endregion


    #region Private Variables

    private List<GameObject> fullSequence = new List<GameObject>();
    private List<GameObject> recipe = new List<GameObject>();
    private int typeOfFood;

    #endregion

    void Awake()
    {
        typeOfFood = GameManager.Instance.gameState.food;
        

        if (typeOfFood == 0)
        {
            buildFruitSequence();
        } else {
            buildDangoSequence();
        }
        
        GameManager.Instance.gameState.recipe = recipe;
        GameManager.Instance.gameState.fullSequence = fullSequence;
    }

    void Start()
    {

        Debug.Log("Actual Recipe Length: ");
        Debug.Log(recipe.Count);
        foreach (GameObject i in recipe)
        {
            Debug.Log(i.name);
        }
        Debug.Log("Full Sequence Length: ");
        Debug.Log(fullSequence.Count);
        foreach (GameObject j in fullSequence)
        {
            Debug.Log(j.name);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            GameManager.Instance.GameScreen();
        }
    }

    private void buildFruitSequence() {
        GameObject curr = null; // just setting default to kiwi for now :)

        int sequenceLength = target + random;

        for (int i = 0; i < (sequenceLength); i++)
        {
            int addTarget = Random.Range(0, target);
            target = target - addTarget;
            for (int j = 0; j < addTarget; j++)
            {
                int n = Random.Range(0, fruits.Count);
                curr = fruits[n];
                fullSequence.Add(curr);
                recipe.Add(curr);
            }

            int addRandom = Random.Range(2, random);
            random = random - addRandom;
            for (int j = 0; j < addRandom; j++)
            {
                int n = Random.Range(0, fruits.Count);
                curr = fruits[n];
                fullSequence.Add(curr);
            }
        }
    }

    private void buildDangoSequence() {
        GameObject curr = null; 

        int sequenceLength = target + random;

        for (int i = 0; i < (sequenceLength); i++)
        {
            int addTarget = Random.Range(0, target);
            target = target - addTarget;
            for (int j = 0; j < addTarget; j++)
            {
                int n = Random.Range(0, dango.Count);
                curr = dango[n];
                fullSequence.Add(curr);
                recipe.Add(curr);
            }

            int addRandom = Random.Range(2, random);
            random = random - addRandom;
            for (int j = 0; j < addRandom; j++)
            {
                int n = Random.Range(0, dango.Count);
                curr = dango[n];
                fullSequence.Add(curr);
            }
        }
    }
}
