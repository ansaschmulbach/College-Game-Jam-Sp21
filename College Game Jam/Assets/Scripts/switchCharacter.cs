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
        customer = GetComponent<Image>();
        cusSprite = customers[customerColor];
        customer.sprite = cusSprite;

        if (customerColor == 0) // purple small one
        {
            this.GetComponent<RectTransform>().sizeDelta = new Vector2(117.521f, 83.94859f); // LOL yes im hard coding values (^u^)b
            this.GetComponent<RectTransform>().anchoredPosition = new Vector3(30.00002f, -171f, 0f);
        }

        if (customerColor == 1) // yellow
        {
            this.GetComponent<RectTransform>().sizeDelta = new Vector2(192.4811f, 234.3617f);
            this.GetComponent<RectTransform>().anchoredPosition = new Vector3(51f, -97f, 0f);
        }

        if (customerColor == 2) // pinky
        {
            this.GetComponent<RectTransform>().sizeDelta = new Vector2(162.2614f, 142.5552f);  
            this.GetComponent<RectTransform>().anchoredPosition = new Vector3(48f, -144f, 0f);
        }
    }

}
