using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RecipeDisplayBuild : MonoBehaviour
{
    #region Inspector Variables

    [SerializeField] [Tooltip("all fruit images")] 
    private List<GameObject> fruitImage;

    [SerializeField] [Tooltip("all dango images")] 
    private List<GameObject> dangoImage;

    [SerializeField] [Tooltip("time between each ingredient shown")] 
    private float fruitDelay;

    [SerializeField] [Tooltip("distance between fruits")] // 28
    private float fruitSpacing;

    [SerializeField] [Tooltip("distance between dangos")] // 30
    private float dangoSpacing;

    [SerializeField] [Tooltip("scene transition timer")] 
    private float sceneTimer;

    [SerializeField] [Tooltip("how low you want to start at skewer")] // -40
    private float height;

    [SerializeField] [Tooltip("how low you want to start at skewer for dangos")] // -50
    private float dangoHeight;

    #endregion
    

    #region Private Variables

    private int fruitIndex;

    private List<GameObject> recipe;

    private float fruitSpawnTimer;

    private float xCoord; 

    private float yCoord;

    private int typeOfFood;

    private float W = Screen.width;
    private float H = Screen.height;

    #endregion

    // Start is called before the first frame update
    void Start()
    {
        height = H * (height / 381);
        dangoHeight = H * (dangoHeight / 381);
        fruitSpacing = H * (fruitSpacing / 381);
        dangoSpacing = H * (dangoSpacing / 381);


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
                float width = W * 275f * (.0002035129314f);
                float he = H * 270f * (.0003616224361f);
             //fruit.GetComponent<RectTransform>().sizeDelta = new Vector2(37.88902f, 37.2001f); // LOL yes im hard coding values (^u^)b
                xCoord = this.transform.position.x + 5;
                fruit.GetComponent<RectTransform>().sizeDelta = new Vector2(width, he);
            }

            if (recipe[fruitIndex].name == "Kiwi") 
            {
                fruit = Instantiate(fruitImage[1]);
                float width = W * 257f * (.000230290823f);
                float he = H * 165f * (.0004092044858f);
                //fruit.GetComponent<RectTransform>().sizeDelta = new Vector2(40.06807f, 25.72464f);
                fruit.GetComponent<RectTransform>().sizeDelta = new Vector2(width, he);
            }

            if (recipe[fruitIndex].name == "Orange") 
            {
                fruit = Instantiate(fruitImage[2]);
                float width = W * 294f * (.0002230438911f);
                float he = H * 172f * (.0003963274431f);
                fruit.GetComponent<RectTransform>().sizeDelta = new Vector2(width, he);
                //fruit.GetComponent<RectTransform>().sizeDelta = new Vector2(44.39421f, 25.97213f);    
            }

            if (recipe[fruitIndex].name == "Pineapple") 
            {
                fruit = Instantiate(fruitImage[3]);
                //fruit.GetComponent<RectTransform>().sizeDelta = new Vector2(42.57622f, 26.87186f);
                float W = Screen.width;
                float H = Screen.height;
                float width = W * 244f * (.0002759051505f);
                float he = H * 154f * (.00045798582f);
                fruit.GetComponent<RectTransform>().sizeDelta = new Vector2(width, he);
            }

            fruit.transform.SetParent(this.gameObject.transform);
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
                float width = W * 285f * (.0001966842883f);
                float he = H * 289f * (.0003494885977f);
                dango.GetComponent<RectTransform>().sizeDelta = new Vector2(width, he);
                //dango.GetComponent<RectTransform>().sizeDelta = new Vector2(37.94925f, 38.48184f); // LOL yes im hard coding values (^u^)b
                //xCoord = this.transform.position.x + 5;
            }

            if (recipe[fruitIndex].name == "Green") 
            {
                dango = Instantiate(dangoImage[1]);
                float width = W * 290f * (.0001848005399f);
                float he = H * 267f * (.000328372801f);
                dango.GetComponent<RectTransform>().sizeDelta = new Vector2(width, he);
                //dango.GetComponent<RectTransform>().sizeDelta = new Vector2(36.28189f, 33.40438f);
            }

            if (recipe[fruitIndex].name == "White") 
            {
                dango = Instantiate(dangoImage[2]);
                float width = W * 280f * (37.28975f / 677f / 280f);
                float he = H * 284f * (37.82246f / 381f / 284f);
                dango.GetComponent<RectTransform>().sizeDelta = new Vector2(width, he);
                //dango.GetComponent<RectTransform>().sizeDelta = new Vector2(37.28975f, 37.82246f);    
            }

            dango.transform.SetParent(this.gameObject.transform);
            dango.transform.position = new Vector3(xCoord, yCoord, 0);
            fruitIndex++;
            dangoHeight = dangoHeight + dangoSpacing;
            yCoord = this.transform.position.y + dangoHeight;
            xCoord = this.transform.position.x + 3;
        }
    }
}
