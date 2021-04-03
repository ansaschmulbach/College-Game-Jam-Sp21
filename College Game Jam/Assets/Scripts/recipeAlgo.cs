using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class recipeAlgo : MonoBehaviour
{
    private enum dangoColor {green, pink, white}
    private enum fruits {strawberry, banana, kiwi, tangerine}

    private List<gameObject> fullSequence = new List<gameObject>();
    private List<gameObject> recipe = new List<gameObject>();

    private int target = 6;
    private int random = 12;

    // Start is called before the first frame update
    void Start()
    {
        // mode being some sort of choice the player makes whether they want to make a fruit kebab or dango... or could be random? 
        // String mode = "fruits"; //debugging purposes
        // if (mode.equals("dango")) {
        //     buildDangoSequence();
        // }
        // if (mode.equals("fruits")) {
        //     buildFruitSequence();
        // }
        // just testing fruit
        buildFruitSequence();

        Debug.Log("Actual Recipe Length: ");
        Debug.Log(recipe.Count);
        foreach (fruits i in recipe)
        {
            Debug.Log(i);
        }
        Debug.Log("Full Sequence Length: ");
        Debug.Log(fullSequence.Count);
        foreach (fruits j in fullSequence)
        {
            Debug.Log(j);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void buildDangoSequence() {
        dangoColor curr = dangoColor.green; // just setting default to green :)
    
        random = target * Random.Range(1, 2); // make at most 3 times the recipe

        int sequenceLength = target + random;

        for (int i = 0; i < (sequenceLength); i++)
        {
            int addTarget = Random.Range(0, 2);
            target = target - addTarget;
            for (int j = 0; j < addTarget; j++) 
            {
                curr = (dangoColor)Random.Range(0, 3);
                fullDangoSequence.Add(curr);
                dangoRecipe.Add(curr);
            }

            int addRandom = Random.Range(0, random);
            random = random - addRandom;
            for (int j = 0; j < addRandom; j++) 
            {
                curr = (dangoColor)Random.Range(0, 3);
                fullDangoSequence.Add(curr);
            }
        }
    }

    private void buildFruitSequence() {
        fruits curr = fruits.kiwi; // just setting default to kiwi for now :)

        target = 6;
        random = target * (Random.Range(1, 2)); // make at most 3 times the recipe

        int sequenceLength = target + random;

        for (int i = 0; i < (sequenceLength); i++)
        {
            int addTarget = Random.Range(0, target);
            target = target - addTarget;
            for (int j = 0; j < addTarget; j++) 
            {
                curr = (fruits)Random.Range(0, 4);
                fullSequence.Add(curr);
                recipe.Add(curr);
            }

            int addRandom = Random.Range(2, random);
            random = random - addRandom;
            for (int j = 0; j < addRandom; j++) 
            {
                curr = (fruits)Random.Range(0, 4);
                fullSequence.Add(curr);
            }
        }
    }

}
