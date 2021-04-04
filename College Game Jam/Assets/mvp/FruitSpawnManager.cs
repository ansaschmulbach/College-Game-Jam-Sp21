using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitSpawnManager : MonoBehaviour
{

    #region Inspector variables

    // [SerializeField] [Tooltip("Fruit will be spawned in this order")]
    // private List<GameObject> fruitPrototypes;

    [SerializeField] [Tooltip("The amount of time between fruit spawns")]
    private float fruitSpawnDelay;

    #endregion
    
    #region Private Variables

    private int fruitIndex;
    private float fruitSpawnTimer;
    private GameObject skewer;
    private List<GameObject> fruitPrototypes;
    private SkewerController skewerScript;

    #endregion

    #region Unity Methods

    void Start()
    {
        fruitSpawnTimer = fruitSpawnDelay/2;
        skewer = GameObject.FindGameObjectWithTag("Skewer");
        fruitPrototypes = GameManager.Instance.gameState.fullSequence;
        skewerScript = skewer.GetComponent<SkewerController>();
    }

    void Update()
    {
        fruitSpawnTimer -= Time.deltaTime;
        if (fruitSpawnTimer <= 0)
        {
            SpawnFruit();
            fruitSpawnTimer = fruitSpawnDelay;
        }
    }

    #endregion

    #region Spawn Fruit method

    void SpawnFruit()
    {
        if (fruitIndex == fruitPrototypes.Count || skewerScript.skeweredItems.Count == skewerScript.maxSkewered)
        {
            Finish();
        }
        else
        {
            GameObject fruit = Instantiate(fruitPrototypes[fruitIndex++]);
            fruit.transform.position = new Vector3(fruit.transform.position.x, fruit.transform.position.y, 
                skewer.transform.position.z - 1);
        }
    }

    #endregion

    void Finish()
    {
        skewer.GetComponent<SkewerController>().SaveAsPrefab();
        GameManager.Instance.LoadToppingScene();
    }

}
