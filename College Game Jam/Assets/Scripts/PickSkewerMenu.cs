using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickSkewerMenu : MonoBehaviour
{

    [SerializeField] private List<Sprite> skewers;
    private int selection;
    
    public void Select0()
    {
        this.selection = 0;
    }

    public void Select1()
    {
        this.selection = 1;
    }

    public void Select2()
    {
        this.selection = 2;
    }

    public void Submit()
    {
        GameManager.Instance.gameState.skewerSprite = skewers[selection];
        GameManager.Instance.GameScreen();
    }

}
