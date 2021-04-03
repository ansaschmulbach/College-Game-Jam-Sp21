using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
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

    private Rigidbody2D rb;

    #endregion

    public bool skewered;
    
    #region Instantiation Methods

    void Start()
    {
        float xPos = Random.Range(-xMax, xMax);
        this.transform.position = new Vector3(xPos, 
            ySpawnCoordinate, this.transform.position.z);
        skewered = false;
    }

    #endregion

    #region Update Methods

    void Update()
    {
        if (!skewered)
        {
            this.transform.position += Vector3.down * fallSpeed * Time.deltaTime;   
        }
        if (this.transform.position.y < -ySpawnCoordinate)
        {
            Destroy(this.gameObject);
        }
    }

    #endregion

    // Spawn controller algorithms??
    
    // A A B D C C A B
    
    // A B A C B B B D A C C A B
    
}
