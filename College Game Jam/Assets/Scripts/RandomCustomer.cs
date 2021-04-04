using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor.Animations;


public class RandomCustomer : MonoBehaviour
{
    [SerializeField] [Tooltip("sprites of all customer characters")] 
    private List<Sprite> customers = new List<Sprite>();
    [SerializeField] [Tooltip("animation for all customers")] 
    private List<AnimatorController> animations = new List<AnimatorController>();
    [SerializeField] [Tooltip("scene transition timer")] 
    private float sceneTimer;

    private Image customer;
    private int random;
    private Sprite cusSprite;
    private int customerColor = 0;

    // Start is called before the first frame update
    void Start()
    {
        random = Random.Range(0, customers.Count);
        GameManager.Instance.gameState.currentCustomer = random;
        customer = GetComponent<Image>();
        //random = Random.Range(0, customers.Count);
        cusSprite = customers[random];
        customer.sprite = cusSprite;

        if (random == 0) // purple small one
        {
            this.GetComponent<RectTransform>().sizeDelta = new Vector2(117.521f, 83.94859f); // LOL yes im hard coding values (^u^)b
            this.GetComponent<Animator>().runtimeAnimatorController = animations[0];
        }

        if (random == 1) // yellow
        {
            this.GetComponent<RectTransform>().sizeDelta = new Vector2(192.4811f, 234.3617f);
            this.GetComponent<Animator>().runtimeAnimatorController = animations[1];
            //this.transform.position = new Vector3(this.transform.position.x + 25, this.transform.position.y + 60, this.transform.position.z);
        }

        if (random == 2) // pinky
        {
            this.GetComponent<RectTransform>().sizeDelta = new Vector2(162.2614f, 142.5552f);  
            this.GetComponent<Animator>().runtimeAnimatorController = animations[2];
            this.transform.position = new Vector3(this.transform.position.x - 35, this.transform.position.y - 30, this.transform.position.z);
        }

        GameManager.Instance.gameState.currentCustomer = random;
    }

    void Update()
    {
        sceneTimer -= Time.deltaTime;
        if (sceneTimer <= 0) 
        {
            GameManager.Instance.Recipe();
        }
    }
}
