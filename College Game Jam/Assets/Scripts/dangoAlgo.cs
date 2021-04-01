using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dangoAlgo : MonoBehaviour
{
    private enum dangoColor {green, pink, white}

    private List<dangoColor> fullSequence = new List<dangoColor>();
    private List<dangoColor> recipe = new List<dangoColor>();

    private int target;
    private int random;

    // Start is called before the first frame update
    void Start()
    {
        buildSequence();
        // Debug.Log("Actual Recipe");
        // foreach (dangoColor i in recipe)
        // {
        //     Debug.Log(i);
        // }
        // Debug.Log("Full Sequence");
        // foreach (dangoColor j in fullSequence)
        // {
        //     Debug.Log(j);
        // }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void buildSequence() {
        dangoColor curr = dangoColor.green; // just setting default to green :)

        target = Random.Range(6, 12); // recipe could have 6 - 12 needed "ingredients"
        random = target * Random.Range(1, 2); // make at most 3 times the recipe

        int sequenceLength = target + random;

        for (int i = 0; i < (sequenceLength); i++)
        {
            int addTarget = Random.Range(0, 2);
            target = target - addTarget;
            for (int j = 0; j < addTarget; j++) 
            {
                curr = (dangoColor)Random.Range(0, 3);
                fullSequence.Add(curr);
                recipe.Add(curr);
            }

            int addRandom = Random.Range(0, random);
            random = random - addRandom;
            for (int j = 0; j < addRandom; j++) 
            {
                curr = (dangoColor)Random.Range(0, 3);
                fullSequence.Add(curr);
            }
        }
    }

}
