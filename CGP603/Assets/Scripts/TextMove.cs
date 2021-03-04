using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextMove : MonoBehaviour
{

    public float TSpeedX;
    public float TSpeedY;
    float moveX;
    float moveY;

    void Update()
    {
        moveX = (TSpeedX * Time.deltaTime) + moveX;
        moveY = (TSpeedY * Time.deltaTime) + moveY;
        if (moveX > 1) moveX = 0;
        if (moveY > 1) moveY = 0;
        GetComponent<Renderer>().material.mainTextureOffset = new Vector2(moveX, moveY);
    }
}
