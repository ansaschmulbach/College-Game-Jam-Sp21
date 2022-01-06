using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.UIElements;
using Quaternion = UnityEngine.Quaternion;
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
    public Sprite condensedMilkSprite;
    
    #endregion

    #region Private Variables

    [SerializeField] public bool frozen = false;
    private Sprite defaultFruitSprite;
    
    #endregion

    #region Public Variables

    [Header("Don't edit")]
    public bool skewered;
    public float maxYCoordinate;

    //toppings variables
    public GameObject sprinkles;
    public GameObject marshmallows;
    
    //toppings variables
    public bool isCondensed;
    public bool hasSprinkles;
    public bool hasMarshmallows;

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
        this.sprinkles.GetComponent<Animator>().SetTrigger("Switched");
    }
    
    public void ToggleMarshmallows()
    {
        hasMarshmallows = !hasMarshmallows;
        this.marshmallows.GetComponent<SpriteRenderer>().enabled = hasMarshmallows;
        this.marshmallows.GetComponent<Animator>().SetTrigger("Switched");
    }

    #endregion

    public static GameObject LoadDango(SkewerSaveData.DangoSaveData dango, SkewerController skewer)
    {
        Vector3 position = new Vector3(dango.position[0], dango.position[1], dango.position[2]);
        Quaternion rotation = Quaternion.Euler(dango.rotation[0], dango.rotation[1], dango.rotation[2]);
        Vector3 localScale = new Vector3(dango.localScale[0], dango.localScale[1], dango.localScale[2]);
        Debug.Log(dango.name);
        GameObject dangoGO = Instantiate(Resources.Load(dango.name, typeof(GameObject)) as GameObject, position, rotation, skewer.transform);
        dangoGO.transform.localScale = localScale;
        dangoGO.transform.localPosition = position;
        dangoGO.transform.localRotation = rotation;
        FoodController fc = dangoGO.GetComponent<FoodController>();
        fc.frozen = true;
        fc.skewered = true;
        fc.maxYCoordinate = -15;
        skewer.skeweredItems.Add(dangoGO);
        return dangoGO;
    }
    
}
