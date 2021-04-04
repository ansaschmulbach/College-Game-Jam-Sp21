﻿using System.Collections;
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

        if (customerColor == 0) // purple small one
        {
            this.GetComponent<RectTransform>().sizeDelta = new Vector2(117.521f, 83.94859f); // LOL yes im hard coding values (^u^)b
            this.GetComponent<RectTransform>().anchoredPosition = new Vector3(30f, -162f, 0f);
        }

        if (customerColor == 1) // yellow
        {
            this.GetComponent<RectTransform>().sizeDelta = new Vector2(192.4811f, 234.3617f);
            this.GetComponent<RectTransform>().anchoredPosition = new Vector3(51f, -97f, 0f);
            //this.GetComponent<Animator>().runtimeAnimatorController = animations[1];
            //this.transform.position = new Vector3(this.transform.position.x + 25, this.transform.position.y + 60, this.transform.position.z);
        }

        if (customerColor == 2) // pinky
        {
            this.GetComponent<RectTransform>().sizeDelta = new Vector2(162.2614f, 142.5552f);  
            //this.GetComponent<Animator>().runtimeAnimatorController = animations[2];
            this.GetComponent<RectTransform>().anchoredPosition = new Vector3(50f, -136.44f, 0f);
            //this.transform.position = new Vector3(this.transform.position.x - 35, this.transform.position.y - 30, this.transform.position.z);
        }
    }

}
