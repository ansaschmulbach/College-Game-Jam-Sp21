using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState
{
    public List<GameObject> fullSequence = new List<GameObject>();

    public List<GameObject> recipe = new List<GameObject>();
    public List<GameObject> currentFruit;

    // UI Image game object of the recipe player needs to make
    public GameObject recipeImage = null;
}
