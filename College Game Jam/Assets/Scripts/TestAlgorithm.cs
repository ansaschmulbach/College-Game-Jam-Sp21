using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestAlgorithm : MonoBehaviour
{
    private enum dangoColor {green, pink, white}
    dangoColor curr = dangoColor.green; // just setting defualt to green :)

    private dangoColor[] recipe; // change to list 

    // TODO: have count for reg fruit/random fruit
    // use this count to build the sequence
    // 

    // Start is called before the first frame update
    void Start()
    {
        

        for (int i = 0; i < 10; i++) { // make at most 3 times the recipe
        // append instead
            curr = (dangoColor)Random.Range(0, 2);
            recipe[i] = curr; //builds the recipe sequence
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
