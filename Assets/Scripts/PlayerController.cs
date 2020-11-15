using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // FixedUpdate is called at a fixed interval and is independent of frame rate
    void FixedUpdate()
    {
        float speedCap = 0.2f;
        float deltaX = Input.GetAxis("Horizontal") * speedCap;
        float deltaY = Input.GetAxis("Vertical") * speedCap;
        float speed = (float) Math.Sqrt(deltaX*deltaX + deltaY*deltaY);
        if (speed > speedCap) {
            deltaX *= speedCap / speed;
            deltaY *= speedCap / speed;
        }
        transform.position = new Vector3(transform.position.x + deltaX, transform.position.y + deltaY, transform.position.y + deltaY - 0.97f); //Z is same as Y, but at bottom of rect
    }
}