using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEditor.U2D;
using UnityEngine;
using UnityEngine.UIElements;
using Vector2 = UnityEngine.Vector2;
using Vector3 = UnityEngine.Vector3;

public class FoodController : MonoBehaviour
{

    #region Inspector Variables

    [SerializeField] [Tooltip("The y coordinate to spawn at")]
    private float ySpawnCoordinate;

    [SerializeField] [Tooltip("X min/max value")]
    private float xMax;

    [SerializeField] [Tooltip("The fall speed")]
    private float fallSpeed;

    [SerializeField] [Tooltip("The condensed milk sprite of this fruit")]
    private Sprite condensedMilkSprite;
    
    #endregion

    #region Private Variables

    [SerializeField] private bool frozen = false;
    private Sprite defaultFruitSprite;

    //toppings variables
    private bool isCondensed;
    private bool hasSprinkles;
    private bool hasMarshmallows;
    
    #endregion

    #region Public Variables

    [Header("Don't edit")]
    public bool skewered;
    public float maxYCoordinate;

    //toppings variables
    public GameObject sprinkles;
    public GameObject marshmallows;
    
    #endregion

    #region Instantiation Methods

    void Start()
    {
        if (!frozen)
        {
            float xPos = Random.Range(-xMax, xMax);
            this.transform.position = new Vector3(xPos, 
                ySpawnCoordinate, this.transform.position.z);
            skewered = false;
            maxYCoordinate = -ySpawnCoordinate;   
        }
        this.defaultFruitSprite = this.GetComponent<SpriteRenderer>().sprite;
        isCondensed = false;
    }

    #endregion

    #region Update Methods

    void Update()
    {
        if (!frozen)
        {
            this.transform.position += Vector3.down * (fallSpeed * Time.deltaTime);   
        }
        if (this.transform.position.y < maxYCoordinate)
        {
            if (!skewered)
            {
                Destroy(this.gameObject);  
            }
            else
            {
                Vector3 pos = this.transform.position;
                this.transform.position = new Vector3(pos.x, maxYCoordinate, pos.z);
                frozen = true;
            }
        }
    }

    #endregion
    
    #region Assembly Methods

    public void UpdateMaxY(float newMax)
    {
        maxYCoordinate = newMax;
        frozen = false;
    }

    #endregion

    #region Toppings Methods

    public void ToggleCondensed()
    {
        if (isCondensed)
        {
            this.GetComponent<SpriteRenderer>().sprite = defaultFruitSprite;
        }
        else
        {
            this.GetComponent<SpriteRenderer>().sprite = condensedMilkSprite;
        }
        
        isCondensed = !isCondensed;

    }
    
    public void ToggleSprinkles()
    {
        hasSprinkles = !hasSprinkles;
        this.sprinkles.GetComponent<SpriteRenderer>().enabled = hasSprinkles;
    }
    
    public void ToggleMarshmallows()
    {
        hasMarshmallows = !hasMarshmallows;
        this.marshmallows.GetComponent<SpriteRenderer>().enabled = hasMarshmallows;
    }

    #endregion
    
    
}
