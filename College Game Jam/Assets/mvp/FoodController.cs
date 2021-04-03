using System.Collections;
using System.Collections.Generic;
using System.Numerics;
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

    #endregion

    #region Private Variables

    [SerializeField]private bool frozen;

    #endregion

    public bool skewered;
    public float maxYCoordinate;
    
    #region Instantiation Methods

    void Start()
    {
        float xPos = Random.Range(-xMax, xMax);
        this.transform.position = new Vector3(xPos, 
            ySpawnCoordinate, this.transform.position.z);
        skewered = false;
        maxYCoordinate = -ySpawnCoordinate;
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

    public void UpdateMaxY(float newMax)
    {
        maxYCoordinate = newMax;
        frozen = false;
    }
    
}
