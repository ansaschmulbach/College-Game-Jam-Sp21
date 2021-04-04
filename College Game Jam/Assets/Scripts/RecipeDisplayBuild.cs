using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecipeDisplayBuild : MonoBehaviour
{
    #region Inspector Variables

    [SerializeField] [Tooltip("all fruit images")] 
    private List<GameObject> fruitImage;

    [SerializeField] [Tooltip("all dango images")] 
    private List<GameObject> dangoImage;

    [SerializeField] [Tooltip("time between each ingredient shown")] 
    private float fruitDelay;

    [SerializeField] [Tooltip("distance between fruits")] 
    private float fruitSpacing;

    [SerializeField] [Tooltip("distance between dangos")] 
    private float dangoSpacing;

    [SerializeField] [Tooltip("scene transition timer")] 
    private float sceneTimer;

    [SerializeField] [Tooltip("how low you want to start at skewer")] 
    private float height;

    [SerializeField] [Tooltip("how low you want to start at skewer for dangos")] 
    private float dangoHeight;
    
    #endregion
    

    #region Private Variables

    private int fruitIndex;

    private List<GameObject> recipe;

    private float fruitSpawnTimer;

    private float xCoord; 

    private float yCoord;

    private int typeOfFood;

    #endregion

    // Start is called before the first frame update
    void Start()
    {
        typeOfFood = GameManager.Instance.gameState.food;
        fruitIndex = 0;
        fruitSpawnTimer = 0;

        // for fruit
        if (typeOfFood == 0) {
            xCoord = this.transform.position.x + 3; // u cannot stop me
            yCoord = this.transform.position.y + height;
        } else { // for dango
            xCoord = this.transform.position.x + 3; // u cannot stop me
            yCoord = this.transform.position.y + dangoHeight;
        }
        
        recipe = GameManager.Instance.gameState.recipe;
    }

    // Update is called once per frame
    void Update()
    {
        fruitSpawnTimer -= Time.deltaTime;
        sceneTimer -= Time.deltaTime;

        if (fruitSpawnTimer <= 0)
        {
            if (typeOfFood == 0) {
                buildRecipe();
            } else { // for dango
                buildDangoRecipe();
            }

            fruitSpawnTimer = fruitDelay;
        }

        GameManager.Instance.gameState.recipeImage = this.gameObject;

        if (sceneTimer <= 0) 
        {
            GameManager.Instance.LoadSkewerPickScene();
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
            height = height + fruitSpacing;
            yCoord = this.transform.position.y + height;
            xCoord = this.transform.position.x + 3;
        }
    }

    private void buildDangoRecipe() 
    {
        if (fruitIndex >= recipe.Count)
        {
            return;
        }
        else
        {
            GameObject dango = null;

            if (recipe[fruitIndex].name == "Pink") 
            {
                dango = Instantiate(dangoImage[0]);
                dango.GetComponent<RectTransform>().sizeDelta = new Vector2(37.94925f, 38.48184f); // LOL yes im hard coding values (^u^)b
                //xCoord = this.transform.position.x + 5;
            }

            if (recipe[fruitIndex].name == "Green") 
            {
                dango = Instantiate(dangoImage[1]);
                dango.GetComponent<RectTransform>().sizeDelta = new Vector2(36.28189f, 33.40438f);
            }

            if (recipe[fruitIndex].name == "White") 
            {
                dango = Instantiate(dangoImage[2]);
                dango.GetComponent<RectTransform>().sizeDelta = new Vector2(37.28975f, 37.82246f);    
            }

            dango.transform.parent = this.transform;
            dango.transform.position = new Vector3(xCoord, yCoord, 0);
            fruitIndex++;
            dangoHeight = dangoHeight + dangoSpacing;
            yCoord = this.transform.position.y + dangoHeight;
            xCoord = this.transform.position.x + 3;
        }
    }
}
