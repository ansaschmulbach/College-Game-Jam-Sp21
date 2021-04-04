using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecipeDisplayBuild : MonoBehaviour
{
    #region Inspector Variables

    [SerializeField] [Tooltip("all fruit images")] 
    private List<GameObject> fruitImage;

    [SerializeField] [Tooltip("time between each ingredient shown")] 
    private float fruitDelay;

    [SerializeField] [Tooltip("distance between fruits")] 
    private float spacing;

    [SerializeField] [Tooltip("scene transition timer")] 
    private float sceneTimer;
    
    #endregion
    

    #region Private Variables

    private int fruitIndex;

    private List<GameObject> recipe;

    private float fruitSpawnTimer;

    private float height;

    private float xCoord; 

    private float yCoord;

    #endregion

    // Start is called before the first frame update
    void Start()
    {
        fruitIndex = 0;
        fruitSpawnTimer = 0;
        height = -40f; // i love hardcoding mwahahah
        xCoord = this.transform.position.x + 3; // u cannot stop me
        yCoord = this.transform.position.y + height;
        recipe = GameManager.Instance.gameState.recipe;

    }

    // Update is called once per frame
    void Update()
    {
        fruitSpawnTimer -= Time.deltaTime;
        sceneTimer -= Time.deltaTime;
        if (fruitSpawnTimer <= 0)
        {
            buildRecipe();
            fruitSpawnTimer = fruitDelay;
        }

        GameManager.Instance.gameState.recipeImage = this.gameObject;

        if (sceneTimer <= 0) 
        {
            GameManager.Instance.GameScreen();
        }
    }

    private void buildRecipe() 
    {
        if (fruitIndex >= recipe.Count)
        {
            return;
        }
        else
        {
            GameObject fruit = null;

            if (recipe[fruitIndex].name == "Strawberry") 
            {
                fruit = Instantiate(fruitImage[0]);
                fruit.GetComponent<RectTransform>().sizeDelta = new Vector2(37.88902f, 37.2001f); // LOL yes im hard coding values (^u^)b
                xCoord = this.transform.position.x + 5;
            }

            if (recipe[fruitIndex].name == "Kiwi") 
            {
                fruit = Instantiate(fruitImage[1]);
                fruit.GetComponent<RectTransform>().sizeDelta = new Vector2(40.06807f, 25.72464f);
            }

            if (recipe[fruitIndex].name == "Orange") 
            {
                fruit = Instantiate(fruitImage[2]);
                fruit.GetComponent<RectTransform>().sizeDelta = new Vector2(44.39421f, 25.97213f);    
            }

            if (recipe[fruitIndex].name == "Pineapple") 
            {
                fruit = Instantiate(fruitImage[3]);
                fruit.GetComponent<RectTransform>().sizeDelta = new Vector2(42.57622f, 26.87186f);
            }

            fruit.transform.parent = this.transform;
            fruit.transform.position = new Vector3(xCoord, yCoord, 0);
            fruitIndex++;
            height = height + spacing;
            yCoord = this.transform.position.y + height;
            xCoord = this.transform.position.x + 3;
        }
    }
}
