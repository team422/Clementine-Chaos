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

        if ((deltaX > 0 && transform.localScale.x > 0) || (deltaX < 0 && transform.localScale.x < 0)) {
            //flip to be facing the right way
            Vector3 scale = transform.localScale;
            scale.x *= -1;
            transform.localScale = scale;
            GetComponent<CircleCollider2D>().transform.localScale = scale;

            Vector3 position = transform.localPosition;
            if (deltaX > 0) {
                position.x += 1f;
            } else {
                position.x -= 1f;
            }
            transform.localPosition = position;
            GetComponent<CircleCollider2D>().transform.localPosition = position;
        }
    }
}