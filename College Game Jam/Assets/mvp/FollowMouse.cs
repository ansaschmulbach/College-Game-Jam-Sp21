using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowMouse : MonoBehaviour
{
    public Camera mainCamera;

    void Update()
    {
        this.transform.position = NewSkewerPos();
    }

    Vector3 NewSkewerPos()
    {
        Vector3 pos = this.transform.position;
        Vector3 mousePos = Input.mousePosition;
        if (mousePos.x > Screen.width)
        {
            mousePos.x = Screen.width;
        } else if (mousePos.x < 0)
        {
            mousePos.x = 0;
        }
        mousePos = mainCamera.ScreenToWorldPoint(mousePos);
        Vector3 newPos = new Vector3(mousePos.x, pos.y, pos.z);
        return newPos;
    }
    
}
