using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class switchCharacter : MonoBehaviour
{
    [SerializeField] [Tooltip("sprites of all customer characters")] 
    private List<Sprite> customers = new List<Sprite>();

    private Image customer;
    private Sprite cusSprite;
    private int customerColor = 0;

    // Start is called before the first frame update
    void Start()
    {
        customerColor = GameManager.Instance.gameState.currentCustomer;
        Debug.Log(customerColor);
        customer = GetComponent<Image>();
        cusSprite = customers[customerColor];
        customer.sprite = cusSprite;
    }

}
