using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MessageManager : MonoBehaviour
{
    public void CustomerEntrance()
    {
        GameManager.Instance.CustomerEnter();   
    }
}
